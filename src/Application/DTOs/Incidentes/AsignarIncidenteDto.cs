using System.ComponentModel.DataAnnotations;

namespace Proyecto.Application.DTOs.Incidentes;

public class AsignarIncidenteDto
{
    [Required]
    public int IncidenteId { get; set; }

    [Required]
    public int UsuarioAsignadoId { get; set; }
    
    [Required]
    public int UsuarioActualId { get; set; }
}
