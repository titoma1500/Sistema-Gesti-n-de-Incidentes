namespace Proyecto.Application.DTOs.Incidentes;

public class IncidenteDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Prioridad { get; set; } = string.Empty;
    public string UsuarioReportaNombre { get; set; } = string.Empty;
    public string? UsuarioAsignadoNombre { get; set; }
    public List<string> Etiquetas { get; set; } = new();
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaSolucion { get; set; }
    public string? MensajeSolucion { get; set; }
}

public class CrearIncidenteDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public int PrioridadId { get; set; }
    public List<int> EtiquetasIds { get; set; } = new();
    public int UsuarioReportaId { get; set; }
}

public class AsignarIncidenteDto
{
    public int IncidenteId { get; set; }
    public int UsuarioAsignadoId { get; set; }
}

public class ResolverIncidenteDto
{
    public int IncidenteId { get; set; }
    public string MensajeSolucion { get; set; } = string.Empty;
}

public class EscalarIncidenteDto
{
    public int IncidenteId { get; set; }
    public int NuevoNivel { get; set; }
    public string MensajeEscalamiento { get; set; } = string.Empty;
}