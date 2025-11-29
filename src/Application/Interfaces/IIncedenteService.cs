using Proyecto.Application.DTOs.Incidentes;

public interface IIncidenteService
{
    // Consultas
    Task<IEnumerable<IncidenteDto>> ObtenerTodosAsync();
    Task<IncidenteDto?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<IncidenteDto>> ObtenerPorUsuarioAsync(int usuarioId);
    Task<IEnumerable<IncidenteDto>> ObtenerPorEstadoAsync(int estadoId);
    Task<IEnumerable<IncidenteDto>> ObtenerPorNivelAsync(int nivel);

    // Operaciones
    Task<IncidenteDto> CrearAsync(CrearIncidenteDto dto);
    Task AsignarAsync(AsignarIncidenteDto dto);
    Task ResolverAsync(ResolverIncidenteDto dto);
    Task EscalarAsync(EscalarIncidenteDto dto);
    Task CerrarAsync(int incidenteId);

    // Búsqueda
    Task<IEnumerable<IncidenteDto>> BuscarPorEtiquetasAsync(List<int> etiquetasIds);
}