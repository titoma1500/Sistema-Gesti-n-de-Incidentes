using Proyecto.Domain.Enums;

namespace Proyecto.Domain.Entities;

public class Incidente
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public EstadoIncidente Estado { get; set; } = EstadoIncidente.Abierto;
    public PrioridadIncidente Prioridad { get; set; } = PrioridadIncidente.Media;
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime? FechaAsignacion { get; set; }
    public DateTime? FechaResolucion { get; set; }
    public string? Resolucion { get; set; }

    // Relaciones
    public int UsuarioReportaId { get; set; }
    public Usuario UsuarioReporta { get; set; } = null!;

    public int? UsuarioAsignadoId { get; set; }
    public Usuario? UsuarioAsignado { get; set; }

    // Escalación
    public int? IncidentePadreId { get; set; }
    public Incidente? IncidentePadre { get; set; }
    public ICollection<Incidente> IncidentesEscalados { get; set; } = new List<Incidente>();
    public string? MensajeEscalacion { get; set; }

    // Descarte
    public string? MotivoDescarte { get; set; }

    // Etiquetas
    public ICollection<Etiqueta> Etiquetas { get; set; } = new List<Etiqueta>();

    // Notificaciones
    public ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
}
