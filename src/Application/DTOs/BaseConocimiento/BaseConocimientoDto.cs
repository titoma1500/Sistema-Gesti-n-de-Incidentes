namespace Proyecto.Application.DTOs.BaseConocimiento;

public class BaseConocimientoDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Solucion { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaActualizacion { get; set; }
    public int VecesConsultada { get; set; }

    // Usuario creador
    public int CreadoPorId { get; set; }
    public string CreadoPorNombre { get; set; } = string.Empty;

    // Etiquetas
    public List<string> Etiquetas { get; set; } = new();
}
