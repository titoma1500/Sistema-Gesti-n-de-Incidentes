public interface IEmailService
{
    Task EnviarEmailAsync(string destinatario, string asunto, string mensaje);
    Task EnviarNotificacionAsignacionAsync(int incidenteId, int usuarioId);
    Task EnviarNotificacionEscalamientoAsync(int incidenteId, int usuarioId);
    Task EnviarNotificacionResolucionAsync(int incidenteId, int usuarioReportaId);
}