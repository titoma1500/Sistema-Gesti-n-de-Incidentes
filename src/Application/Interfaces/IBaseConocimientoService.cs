using Proyecto.Application.DTOs.BaseConocimiento;

public interface IBaseConocimientoService
{
    Task<IEnumerable<BaseConocimientoDto>> ObtenerTodosAsync();
    Task<BaseConocimientoDto?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<BaseConocimientoDto>> BuscarAsync(BuscarBaseConocimientoDto dto);
    Task<IEnumerable<BaseConocimientoDto>> BuscarPorEtiquetasAsync(List<int> etiquetasIds);
    Task<BaseConocimientoDto> CrearAsync(CrearBaseConocimientoDto dto);
    Task IncrementarConsultasAsync(int id);
}