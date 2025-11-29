using Microsoft.EntityFrameworkCore;
using Proyecto.Application.DTOs.BaseConocimiento;
using Proyecto.Application.Interfaces;
using Proyecto.Domain.Entities;
using Proyecto.Infrastructure.Data;
using Proyecto.Infrastructure.Repositories;

namespace Proyecto.Application.Services;

public class BaseConocimientoService : IBaseConocimientoService
{
    private readonly IBaseConocimientoRepository _baseConocimientoRepository;
    private readonly ApplicationDbContext _context;

    public BaseConocimientoService(
        IBaseConocimientoRepository baseConocimientoRepository,
        ApplicationDbContext context)
    {
        _baseConocimientoRepository = baseConocimientoRepository;
        _context = context;
    }

    public async Task<IEnumerable<BaseConocimientoDto>> ObtenerTodosAsync()
    {
        var articulos = await _baseConocimientoRepository.ObtenerTodosAsync();
        return articulos.Select(MapearADto);
    }

    public async Task<BaseConocimientoDto?> ObtenerPorIdAsync(int id)
    {
        var articulo = await _baseConocimientoRepository.ObtenerPorIdAsync(id);
        if (articulo != null)
        {
            await IncrementarConsultasAsync(id);
        }
        return articulo != null ? MapearADto(articulo) : null;
    }

    public async Task<IEnumerable<BaseConocimientoDto>> BuscarAsync(BuscarBaseConocimientoDto dto)
    {
        IEnumerable<BaseConocimiento> articulos;

        if (dto.EtiquetasIds != null && dto.EtiquetasIds.Any())
        {
            // Buscar por etiquetas
            articulos = await _baseConocimientoRepository.BuscarPorEtiquetasAsync(dto.EtiquetasIds);
        }
        else if (!string.IsNullOrWhiteSpace(dto.TextoBusqueda))
        {
            // Buscar por texto
            articulos = await _baseConocimientoRepository.BuscarPorTextoAsync(dto.TextoBusqueda);
        }
        else
        {
            // Devolver todos
            articulos = await _baseConocimientoRepository.ObtenerTodosAsync();
        }

        return articulos.Select(MapearADto);
    }

    public async Task<BaseConocimientoDto> CrearAsync(CrearArticuloDto dto)
    {
        var articulo = new BaseConocimiento
        {
            Titulo = dto.Titulo,
            Descripcion = dto.Descripcion,
            Solucion = dto.Solucion,
            CreadoPorId = dto.CreadoPorId,
            FechaCreacion = DateTime.Now,
            FechaActualizacion = DateTime.Now,
            VecesConsultada = 0
        };

        // Cargar etiquetas
        if (dto.EtiquetasIds != null && dto.EtiquetasIds.Any())
        {
            var etiquetas = await _context.Etiquetas
                .Where(e => dto.EtiquetasIds.Contains(e.Id))
                .ToListAsync();
            articulo.Etiquetas = etiquetas;
        }

        var articuloCreado = await _baseConocimientoRepository.CrearAsync(articulo);
        
        // Recargar con todas las relaciones
        var articuloCompleto = await _baseConocimientoRepository.ObtenerPorIdAsync(articuloCreado.Id);
        return MapearADto(articuloCompleto!);
    }

    public async Task IncrementarConsultasAsync(int id)
    {
        await _baseConocimientoRepository.IncrementarConsultasAsync(id);
    }

    public async Task<IEnumerable<BaseConocimientoDto>> ObtenerPorEtiquetasAsync(List<string> etiquetas)
    {
        if (etiquetas == null || !etiquetas.Any())
            return Enumerable.Empty<BaseConocimientoDto>();

        var todosArticulos = await _baseConocimientoRepository.ObtenerTodosAsync();
        
        // Filtrar artículos que tengan al menos una etiqueta en común
        var articulosFiltrados = todosArticulos
            .Where(a => a.Etiquetas.Any(e => etiquetas.Contains(e.Nombre)))
            .OrderByDescending(a => a.VecesConsultada)
            .Take(5); // Máximo 5 sugerencias
            
        return articulosFiltrados.Select(MapearADto);
    }

    private BaseConocimientoDto MapearADto(BaseConocimiento articulo)
    {
        return new BaseConocimientoDto
        {
            Id = articulo.Id,
            Titulo = articulo.Titulo,
            Descripcion = articulo.Descripcion,
            Solucion = articulo.Solucion,
            FechaCreacion = articulo.FechaCreacion,
            FechaActualizacion = articulo.FechaActualizacion,
            VecesConsultada = articulo.VecesConsultada,
            CreadoPorId = articulo.CreadoPorId,
            CreadoPorNombre = articulo.CreadoPor?.Nombre ?? "",
            Etiquetas = articulo.Etiquetas?.Select(e => e.Nombre).ToList() ?? new List<string>()
        };
    }
}
