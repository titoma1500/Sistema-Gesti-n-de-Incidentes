using System.ComponentModel.DataAnnotations;

namespace Proyecto.Application.DTOs.Incidentes;

public class CrearIncidenteDto
{
    [Required(ErrorMessage = "El título es requerido")]
    [MaxLength(300)]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción es requerida")]
    public string Descripcion { get; set; } = string.Empty;

    [Required]
    public int PrioridadId { get; set; }

    [Required]
    public int UsuarioReportaId { get; set; }

    public List<int> EtiquetasIds { get; set; } = new();
}
