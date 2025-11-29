using Proyecto.Domain.Enums;

namespace Proyecto.Domain.Entities;

public class Etiqueta
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public CategoriaEtiqueta Categoria { get; set; }
    public string? Descripcion { get; set; }

    // Navegación
    public ICollection<Incidente> Incidentes { get; set; } = new List<Incidente>();
    public ICollection<BaseConocimiento> ArticulosConocimiento { get; set; } = new List<BaseConocimiento>();
}
