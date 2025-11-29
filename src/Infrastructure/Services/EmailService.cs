using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace Proyecto.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task EnviarEmailAsync(string destinatario, string asunto, string cuerpo)
    {
        var smtpHost = _configuration["Email:SmtpHost"] ?? "smtp.gmail.com";
        var smtpPort = int.Parse(_configuration["Email:SmtpPort"] ?? "587");
        var fromEmail = _configuration["Email:From"] ?? "noreply@universidad.edu";
        var fromPassword = _configuration["Email:Password"] ?? "";

        using var smtpClient = new SmtpClient(smtpHost, smtpPort)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(fromEmail, fromPassword)
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(fromEmail, "Sistema de Incidentes"),
            Subject = asunto,
            Body = cuerpo,
            IsBodyHtml = true
        };
        mailMessage.To.Add(destinatario);

        await smtpClient.SendMailAsync(mailMessage);
    }

    public async Task EnviarNotificacionIncidenteAsync(string destinatario, string tituloIncidente, string mensaje)
    {
        var cuerpo = $@"
            <html>
                <body>
                    <h2>Notificación de Incidente</h2>
                    <p><strong>Incidente:</strong> {tituloIncidente}</p>
                    <p><strong>Mensaje:</strong> {mensaje}</p>
                    <hr/>
                    <p>Sistema de Gestión de Incidentes - Universidad</p>
                </body>
            </html>";

        await EnviarEmailAsync(destinatario, $"Incidente: {tituloIncidente}", cuerpo);
    }

    public async Task EnviarNotificacionAsignacionAsync(string emailTecnico, string tituloIncidente)
    {
        await EnviarNotificacionIncidenteAsync(emailTecnico, tituloIncidente, "Se te ha asignado un nuevo incidente.");
    }

    public async Task EnviarNotificacionEscalacionAsync(string emailTecnico, string tituloIncidente, string mensaje)
    {
        await EnviarNotificacionIncidenteAsync(emailTecnico, tituloIncidente, $"Incidente escalado: {mensaje}");
    }

    public async Task EnviarNotificacionResolucionAsync(string emailUsuario, string tituloIncidente, string resolucion)
    {
        await EnviarNotificacionIncidenteAsync(emailUsuario, tituloIncidente, $"Tu incidente ha sido resuelto: {resolucion}");
    }

    public async Task EnviarNotificacionDescartadoAsync(string emailUsuario, string tituloIncidente, string motivo)
    {
        await EnviarNotificacionIncidenteAsync(emailUsuario, tituloIncidente, $"Tu incidente ha sido descartado. Motivo: {motivo}");
    }
}
