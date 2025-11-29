using Proyecto.Domain.Entities;

namespace Proyecto.Infrastructure.Repositories;

public interface IBaseConocimientoRepository
{
    Task<IEnumerable<BaseConocimiento>> ObtenerTodosAsync();
    Task<BaseConocimiento?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<BaseConocimiento>> BuscarPorEtiquetasAsync(List<int> etiquetasIds);
    Task<IEnumerable<BaseConocimiento>> BuscarPorTextoAsync(string texto);
    Task<BaseConocimiento> CrearAsync(BaseConocimiento articulo);
    Task ActualizarAsync(BaseConocimiento articulo);
    Task IncrementarConsultasAsync(int id);
}
