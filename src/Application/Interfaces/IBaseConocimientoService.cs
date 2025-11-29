using Proyecto.Application.DTOs.BaseConocimiento;

namespace Proyecto.Application.Interfaces;

public interface IBaseConocimientoService
{
    Task<IEnumerable<BaseConocimientoDto>> ObtenerTodosAsync();
    Task<BaseConocimientoDto?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<BaseConocimientoDto>> BuscarAsync(BuscarBaseConocimientoDto dto);
    Task<IEnumerable<BaseConocimientoDto>> ObtenerPorEtiquetasAsync(List<string> etiquetas);
    Task<BaseConocimientoDto> CrearAsync(CrearArticuloDto dto);
    Task IncrementarConsultasAsync(int id);
}
