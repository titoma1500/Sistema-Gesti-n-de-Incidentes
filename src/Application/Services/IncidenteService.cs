using Microsoft.EntityFrameworkCore;
using Proyecto.Application.DTOs.Incidentes;
using Proyecto.Application.Interfaces;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Enums;
using Proyecto.Infrastructure.Data;
using Proyecto.Infrastructure.Repositories;

namespace Proyecto.Application.Services;

public class IncidenteService : IIncidenteService
{
    private readonly IIncidenteRepository _incidenteRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IEmailService _emailService;
    private readonly ApplicationDbContext _context;

    public IncidenteService(
        IIncidenteRepository incidenteRepository,
        IUsuarioRepository usuarioRepository,
        IEmailService emailService,
        ApplicationDbContext context)
    {
        _incidenteRepository = incidenteRepository;
        _usuarioRepository = usuarioRepository;
        _emailService = emailService;
        _context = context;
    }

    public async Task<IEnumerable<IncidenteDto>> ObtenerTodosAsync()
    {
        var incidentes = await _incidenteRepository.ObtenerTodosAsync();
        return incidentes.Select(MapearADto);
    }

    public async Task<IncidenteDto?> ObtenerPorIdAsync(int id)
    {
        var incidente = await _incidenteRepository.ObtenerPorIdAsync(id);
        return incidente != null ? MapearADto(incidente) : null;
    }

    public async Task<IEnumerable<IncidenteDto>> ObtenerPorEstadoAsync(int estadoId)
    {
        var incidentes = await _incidenteRepository.ObtenerPorEstadoAsync(estadoId);
        return incidentes.Select(MapearADto);
    }

    public async Task<IEnumerable<IncidenteDto>> ObtenerPorUsuarioAsync(int usuarioId)
    {
        var incidentes = await _incidenteRepository.ObtenerPorUsuarioAsync(usuarioId);
        return incidentes.Select(MapearADto);
    }

    public async Task<IEnumerable<IncidenteDto>> ObtenerPorAsignadoAsync(int usuarioAsignadoId)
    {
        var incidentes = await _incidenteRepository.ObtenerPorAsignadoAsync(usuarioAsignadoId);
        return incidentes.Select(MapearADto);
    }

    public async Task<IncidenteDto> CrearAsync(CrearIncidenteDto dto)
    {
        var incidente = new Incidente
        {
            Titulo = dto.Titulo,
            Descripcion = dto.Descripcion,
            Prioridad = (PrioridadIncidente)dto.PrioridadId,
            UsuarioReportaId = dto.UsuarioReportaId,
            Estado = EstadoIncidente.Abierto,
            FechaCreacion = DateTime.Now
        };

        // Cargar etiquetas
        if (dto.EtiquetasIds != null && dto.EtiquetasIds.Any())
        {
            var etiquetas = await _context.Etiquetas
                .Where(e => dto.EtiquetasIds.Contains(e.Id))
                .ToListAsync();
            incidente.Etiquetas = etiquetas;
        }

        var incidenteCreado = await _incidenteRepository.CrearAsync(incidente);
        
        // Recargar el incidente con todas las relaciones
        var incidenteCompleto = await _incidenteRepository.ObtenerPorIdAsync(incidenteCreado.Id);
        
        // Notificar a administradores (Nivel 4)
        try
        {
            var admins = await _usuarioRepository.ObtenerPorNivelAsync(4);
            foreach (var admin in admins)
            {
                await _emailService.EnviarNotificacionAsignacionAsync(admin.Email, incidente.Titulo);
            }
        }
        catch (Exception)
        {
            // Ignorar errores de email - no bloquear la creación del incidente
        }

        return MapearADto(incidenteCompleto!);
    }

    public async Task AsignarAsync(AsignarIncidenteDto dto)
    {
        var incidente = await _incidenteRepository.ObtenerPorIdAsync(dto.IncidenteId);
        if (incidente == null)
            throw new Exception("Incidente no encontrado");

        var tecnico = await _usuarioRepository.ObtenerPorIdAsync(dto.UsuarioAsignadoId);
        if (tecnico == null)
            throw new Exception("Técnico no encontrado");

        incidente.UsuarioAsignadoId = dto.UsuarioAsignadoId;
        incidente.Estado = EstadoIncidente.Asignado;
        incidente.FechaAsignacion = DateTime.Now;

        await _incidenteRepository.ActualizarAsync(incidente);

        // Enviar notificación al técnico
        try
        {
            await _emailService.EnviarNotificacionAsignacionAsync(tecnico.Email, incidente.Titulo);
        }
        catch (Exception)
        {
            // Ignorar errores de email
        }
    }

    public async Task EscalarAsync(EscalarIncidenteDto dto)
    {
        var incidente = await _incidenteRepository.ObtenerPorIdAsync(dto.IncidenteId);
        if (incidente == null)
            throw new Exception("Incidente no encontrado");

        var tecnicoNivelSuperior = await _usuarioRepository.ObtenerPorIdAsync(dto.UsuarioAsignadoId);
        if (tecnicoNivelSuperior == null)
            throw new Exception("Técnico del nivel superior no encontrado");

        // Actualizar incidente: asignar al técnico del nivel superior y cambiar estado
        incidente.UsuarioAsignadoId = dto.UsuarioAsignadoId;
        incidente.Estado = EstadoIncidente.Escalado;
        incidente.MensajeEscalacion = dto.MensajeEscalacion;
        incidente.FechaAsignacion = DateTime.Now;

        await _incidenteRepository.ActualizarAsync(incidente);

        // Notificar al técnico del nivel superior
        try
        {
            await _emailService.EnviarNotificacionEscalacionAsync(
                tecnicoNivelSuperior.Email, 
                incidente.Titulo, 
                dto.MensajeEscalacion);
        }
        catch (Exception)
        {
            // Ignorar errores de email
        }
    }

    public async Task ResolverAsync(ResolverIncidenteDto dto)
    {
        var incidente = await _incidenteRepository.ObtenerPorIdAsync(dto.IncidenteId);
        if (incidente == null)
            throw new Exception("Incidente no encontrado");

        incidente.Estado = EstadoIncidente.Resuelto;
        incidente.Resolucion = dto.Resolucion;
        incidente.FechaResolucion = DateTime.Now;

        await _incidenteRepository.ActualizarAsync(incidente);

        // Notificar al usuario que reportó
        try
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(incidente.UsuarioReportaId);
            if (usuario != null)
            {
                await _emailService.EnviarNotificacionResolucionAsync(
                    usuario.Email, 
                    incidente.Titulo, 
                    dto.Resolucion);
            }
        }
        catch (Exception)
        {
            // Ignorar errores de email
        }
    }

    public async Task CerrarAsync(int incidenteId)
    {
        var incidente = await _incidenteRepository.ObtenerPorIdAsync(incidenteId);
        if (incidente == null)
            throw new Exception("Incidente no encontrado");

        if (incidente.Estado != EstadoIncidente.Resuelto)
            throw new Exception("Solo se pueden cerrar incidentes resueltos");

        incidente.Estado = EstadoIncidente.Cerrado;
        await _incidenteRepository.ActualizarAsync(incidente);
    }

    public async Task DescartarAsync(DescartarIncidenteDto dto)
    {
        var incidente = await _incidenteRepository.ObtenerPorIdAsync(dto.IncidenteId);
        if (incidente == null)
            throw new Exception("Incidente no encontrado");

        incidente.Estado = EstadoIncidente.Descartado;
        incidente.MotivoDescarte = dto.MotivoDescarte;
        await _incidenteRepository.ActualizarAsync(incidente);

        // Notificar al usuario que reportó
        try
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(incidente.UsuarioReportaId);
            if (usuario != null)
            {
                await _emailService.EnviarNotificacionDescartadoAsync(
                    usuario.Email,
                    incidente.Titulo,
                    dto.MotivoDescarte);
            }
        }
        catch (Exception)
        {
            // Ignorar errores de email
        }
    }

    public async Task<bool> ValidarLimiteIncidentesAsync(int usuarioId)
    {
        var incidentesUsuario = await _incidenteRepository.ObtenerPorUsuarioAsync(usuarioId);
        
        // Contar incidentes activos (no resueltos, cerrados ni descartados)
        var incidentesActivos = incidentesUsuario.Count(i => 
            i.Estado != EstadoIncidente.Resuelto && 
            i.Estado != EstadoIncidente.Cerrado &&
            i.Estado != EstadoIncidente.Descartado);
        
        // Retorna true si puede crear más incidentes (menos de 3 activos)
        return incidentesActivos < 3;
    }

    private IncidenteDto MapearADto(Incidente incidente)
    {
        return new IncidenteDto
        {
            Id = incidente.Id,
            Titulo = incidente.Titulo,
            Descripcion = incidente.Descripcion,
            Estado = incidente.Estado.ToString(),
            Prioridad = incidente.Prioridad.ToString(),
            FechaCreacion = incidente.FechaCreacion,
            FechaAsignacion = incidente.FechaAsignacion,
            FechaResolucion = incidente.FechaResolucion,
            Resolucion = incidente.Resolucion,
            UsuarioReportaId = incidente.UsuarioReportaId,
            UsuarioReportaNombre = incidente.UsuarioReporta?.Nombre ?? "",
            UsuarioAsignadoId = incidente.UsuarioAsignadoId,
            UsuarioAsignadoNombre = incidente.UsuarioAsignado?.Nombre,
            NivelAsignado = incidente.UsuarioAsignado != null ? (int)incidente.UsuarioAsignado.Nivel : null,
            EspecialidadAsignado = incidente.UsuarioAsignado?.Especialidad,
            IncidentePadreId = incidente.IncidentePadreId,
            MensajeEscalacion = incidente.MensajeEscalacion,
            MotivoDescarte = incidente.MotivoDescarte,
            Etiquetas = incidente.Etiquetas?.Select(e => e.Nombre).ToList() ?? new List<string>()
        };
    }
}
