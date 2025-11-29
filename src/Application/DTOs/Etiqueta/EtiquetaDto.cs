namespace Proyecto.Application.DTOs.Etiqueta;

public class EtiquetaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
}
