using Proyecto.Domain.Enums;

namespace Proyecto.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public NivelUsuario Nivel { get; set; }
    public string? Especialidad { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    // Navegación
    public ICollection<Incidente> IncidentesReportados { get; set; } = new List<Incidente>();
    public ICollection<Incidente> IncidentesAsignados { get; set; } = new List<Incidente>();
    public ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
}
