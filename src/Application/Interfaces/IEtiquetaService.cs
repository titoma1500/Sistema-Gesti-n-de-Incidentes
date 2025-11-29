using Proyecto.Application.DTOs.Etiqueta;

namespace Proyecto.Application.Interfaces;

public interface IEtiquetaService
{
    Task<IEnumerable<EtiquetaDto>> ObtenerTodasAsync();
    Task<EtiquetaDto?> ObtenerPorIdAsync(int id);
}
