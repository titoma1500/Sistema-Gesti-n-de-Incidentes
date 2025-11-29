namespace Proyecto.Application.DTOs.BaseConocimiento;

public class CrearArticuloDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Solucion { get; set; } = string.Empty;
    public int CreadoPorId { get; set; }
    public List<int> EtiquetasIds { get; set; } = new();
}
