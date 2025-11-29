using Proyecto.Domain.Enums;

namespace Proyecto.Domain.Entities;

public class Notificacion
{
    public int Id { get; set; }
    public TipoNotificacion Tipo { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public bool Leida { get; set; } = false;
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    // Relaciones
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public int? IncidenteId { get; set; }
    public Incidente? Incidente { get; set; }
}
