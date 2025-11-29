using Proyecto.Application.DTOs.BaseConocimiento;

public class BaseConocimientoService : IBaseConocimientoService
{
    private readonly IBaseConocimientoRepository _repository;

    public BaseConocimientoService(IBaseConocimientoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BaseConocimientoDto>> BuscarAsync(
        BuscarBaseConocimientoDto dto)
    {
        var articulos = await _repository.BuscarAsync(
            dto.TextoBusqueda,
            dto.EtiquetasIds
        );

        return articulos.Select(MapearADto);
    }

    public async Task IncrementarConsultasAsync(int id)
    {
        var articulo = await _repository.ObtenerPorIdAsync(id);
        if (articulo != null)
        {
            articulo.VecesConsultada++;
            await _repository.ActualizarAsync(articulo);
        }
    }

    private BaseConocimientoDto MapearADto(BaseConocimiento articulo)
    {
        return new BaseConocimientoDto
        {
            Id = articulo.Id,
            Titulo = articulo.Titulo,
            Descripcion = articulo.Descripcion,
            Solucion = articulo.Solucion,
            VecesConsultada = articulo.VecesConsultada,
            FechaCreacion = articulo.FechaCreacion,
            Etiquetas = articulo.Etiquetas?.Select(e => e.Nombre).ToList() ?? new()
        };
    }

    // Implementar otros métodos...
}