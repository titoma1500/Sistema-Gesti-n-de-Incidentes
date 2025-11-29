using System.ComponentModel.DataAnnotations;

namespace Proyecto.Application.DTOs.BaseConocimiento;

public class CrearBaseConocimientoDto
{
    [Required(ErrorMessage = "El título es requerido")]
    [MaxLength(300)]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción es requerida")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "La solución es requerida")]
    public string Solucion { get; set; } = string.Empty;

    [Required]
    public int CreadoPorId { get; set; }

    public List<int> EtiquetasIds { get; set; } = new();
}
