using System.ComponentModel.DataAnnotations;

namespace Proyecto.Application.DTOs.Incidentes;

public class DescartarIncidenteDto
{
    [Required]
    public int IncidenteId { get; set; }

    [Required(ErrorMessage = "Debe proporcionar el motivo del descarte")]
    public string MotivoDescarte { get; set; } = string.Empty;
    
    [Required]
    public int UsuarioActualId { get; set; }
}
