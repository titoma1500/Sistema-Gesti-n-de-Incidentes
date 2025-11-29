using Proyecto.Application.DTOs.Incidentes;

namespace Proyecto.Application.Services;

public class IncidenteService : IIncidenteService
{
    private readonly IIncidenteRepository _incidenteRepo;
    private readonly IUsuarioRepository _usuarioRepo;
    private readonly IEmailService _emailService;

    public IncidenteService(
        IIncidenteRepository incidenteRepo,
        IUsuarioRepository usuarioRepo,
        IEmailService emailService)
    {
        _incidenteRepo = incidenteRepo;
        _usuarioRepo = usuarioRepo;
        _emailService = emailService;
    }

    public async Task<IncidenteDto> CrearAsync(CrearIncidenteDto dto)
    {
        var incidente = new Incidente
        {
            Titulo = dto.Titulo,
            Descripcion = dto.Descripcion,
            Prioridad = (PrioridadIncidente)dto.PrioridadId,
            Estado = EstadoIncidente.Abierto,
            UsuarioReportaId = dto.UsuarioReportaId,
            FechaCreacion = DateTime.Now
        };

        // Asignar etiquetas
        // TODO: Agregar lógica para etiquetas

        await _incidenteRepo.CrearAsync(incidente);

        return MapearADto(incidente);
    }

    public async Task AsignarAsync(AsignarIncidenteDto dto)
    {
        var incidente = await _incidenteRepo.ObtenerPorIdAsync(dto.IncidenteId);
        if (incidente == null)
            throw new Exception("Incidente no encontrado");

        incidente.UsuarioAsignadoId = dto.UsuarioAsignadoId;
        incidente.Estado = EstadoIncidente.Asignado;
        incidente.FechaAsignacion = DateTime.Now;

        await _incidenteRepo.ActualizarAsync(incidente);

        // Enviar notificación por email
        await _emailService.EnviarNotificacionAsignacionAsync(
            dto.IncidenteId,
            dto.UsuarioAsignadoId
        );
    }

    public async Task EscalarAsync(EscalarIncidenteDto dto)
    {
        var incidente = await _incidenteRepo.ObtenerPorIdAsync(dto.IncidenteId);
        if (incidente == null)
            throw new Exception("Incidente no encontrado");

        // Validar que el nuevo nivel sea mayor
        var usuarioActual = await _usuarioRepo.ObtenerPorIdAsync(
            incidente.UsuarioAsignadoId ?? 0
        );

        if (usuarioActual == null || (int)usuarioActual.Nivel >= dto.NuevoNivel)
            throw new Exception("Nivel de escalamiento inválido");

        incidente.MensajeEscalamiento = dto.MensajeEscalamiento;
        incidente.UsuarioAsignadoId = null; // Desasignar para que admin asigne
        incidente.Estado = EstadoIncidente.Abierto;

        await _incidenteRepo.ActualizarAsync(incidente);

        // TODO: Notificar a usuarios del nuevo nivel
    }

    public async Task ResolverAsync(ResolverIncidenteDto dto)
    {
        var incidente = await _incidenteRepo.ObtenerPorIdAsync(dto.IncidenteId);
        if (incidente == null)
            throw new Exception("Incidente no encontrado");

        incidente.Estado = EstadoIncidente.Resuelto;
        incidente.MensajeSolucion = dto.MensajeSolucion;
        incidente.FechaSolucion = DateTime.Now;

        await _incidenteRepo.ActualizarAsync(incidente);

        // Notificar al usuario que reportó
        await _emailService.EnviarNotificacionResolucionAsync(
            dto.IncidenteId,
            incidente.UsuarioReportaId
        );
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
            UsuarioReportaNombre = incidente.UsuarioReporta?.Nombre ?? "",
            UsuarioAsignadoNombre = incidente.UsuarioAsignado?.Nombre,
            FechaCreacion = incidente.FechaCreacion,
            FechaSolucion = incidente.FechaSolucion,
            MensajeSolucion = incidente.MensajeSolucion,
            Etiquetas = incidente.Etiquetas?.Select(e => e.Nombre).ToList() ?? new()
        };
    }

    // Implementar otros métodos...
}