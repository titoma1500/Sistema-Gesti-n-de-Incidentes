namespace Proyecto.Domain.Entities;

public class BaseConocimiento
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Solucion { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime? FechaActualizacion { get; set; }
    public int VecesConsultada { get; set; } = 0;

    // Relación con Usuario que creó el artículo
    public int CreadoPorId { get; set; }
    public Usuario CreadoPor { get; set; } = null!;

    // Etiquetas para búsqueda
    public ICollection<Etiqueta> Etiquetas { get; set; } = new List<Etiqueta>();
}
