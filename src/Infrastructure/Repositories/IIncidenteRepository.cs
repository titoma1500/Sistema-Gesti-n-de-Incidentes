using Proyecto.Domain.Entities;

namespace Proyecto.Infrastructure.Repositories;

public interface IIncidenteRepository
{
    Task<IEnumerable<Incidente>> ObtenerTodosAsync();
    Task<Incidente?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<Incidente>> ObtenerPorEstadoAsync(int estadoId);
    Task<IEnumerable<Incidente>> ObtenerPorUsuarioAsync(int usuarioId);
    Task<IEnumerable<Incidente>> ObtenerPorAsignadoAsync(int usuarioAsignadoId);
    Task<Incidente> CrearAsync(Incidente incidente);
    Task ActualizarAsync(Incidente incidente);
    Task EliminarAsync(int id);
}
