namespace Proyecto.Application.DTOs.Incidentes;

public class IncidenteDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Prioridad { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaAsignacion { get; set; }
    public DateTime? FechaResolucion { get; set; }
    public string? Resolucion { get; set; }

    // Usuario que reporta
    public int UsuarioReportaId { get; set; }
    public string UsuarioReportaNombre { get; set; } = string.Empty;

    // Usuario asignado
    public int? UsuarioAsignadoId { get; set; }
    public string? UsuarioAsignadoNombre { get; set; }
    public int? NivelAsignado { get; set; }
    public string? EspecialidadAsignado { get; set; }

    // Escalación
    public int? IncidentePadreId { get; set; }
    public string? MensajeEscalacion { get; set; }

    // Descarte
    public string? MotivoDescarte { get; set; }

    // Etiquetas
    public List<string> Etiquetas { get; set; } = new();
}
