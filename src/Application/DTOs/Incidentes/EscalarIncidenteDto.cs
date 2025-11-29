using System.ComponentModel.DataAnnotations;

namespace Proyecto.Application.DTOs.Incidentes;

public class EscalarIncidenteDto
{
    [Required]
    public int IncidenteId { get; set; }

    [Required]
    public int NuevoNivel { get; set; }

    [Required]
    public int UsuarioAsignadoId { get; set; }

    [Required(ErrorMessage = "El mensaje de escalación es requerido")]
    public string MensajeEscalacion { get; set; } = string.Empty;
}
