using Proyecto.Application.DTOs.Incidentes;

namespace Proyecto.Application.Interfaces;

public interface IIncidenteService
{
    Task<IEnumerable<IncidenteDto>> ObtenerTodosAsync();
    Task<IncidenteDto?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<IncidenteDto>> ObtenerPorEstadoAsync(int estadoId);
    Task<IEnumerable<IncidenteDto>> ObtenerPorUsuarioAsync(int usuarioId);
    Task<IEnumerable<IncidenteDto>> ObtenerPorAsignadoAsync(int usuarioAsignadoId);
    Task<IncidenteDto> CrearAsync(CrearIncidenteDto dto);
    Task AsignarAsync(AsignarIncidenteDto dto);
    Task EscalarAsync(EscalarIncidenteDto dto);
    Task ResolverAsync(ResolverIncidenteDto dto);
    Task CerrarAsync(int incidenteId);
    Task DescartarAsync(DescartarIncidenteDto dto);
    Task<bool> ValidarLimiteIncidentesAsync(int usuarioId);
}
