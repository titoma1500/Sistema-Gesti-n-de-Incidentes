namespace Proyecto.Infrastructure.Services;

public interface IEmailService
{
    Task EnviarEmailAsync(string destinatario, string asunto, string cuerpo);
    Task EnviarNotificacionIncidenteAsync(string destinatario, string tituloIncidente, string mensaje);
}
