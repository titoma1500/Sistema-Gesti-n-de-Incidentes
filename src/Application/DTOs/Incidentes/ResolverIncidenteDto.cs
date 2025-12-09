using System.ComponentModel.DataAnnotations;

namespace Proyecto.Application.DTOs.Incidentes;

public class ResolverIncidenteDto
{
    [Required]
    public int IncidenteId { get; set; }

    [Required(ErrorMessage = "La resolución es requerida")]
    public string Resolucion { get; set; } = string.Empty;
    
    [Required]
    public int UsuarioActualId { get; set; }
}
