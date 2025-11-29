using Proyecto.Application.Interfaces;

namespace Proyecto.Application.Services;

public class EmailServiceAdapter : IEmailService
{
    private readonly Infrastructure.Services.IEmailService _emailService;

    public EmailServiceAdapter(Infrastructure.Services.IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task EnviarNotificacionAsignacionAsync(string emailTecnico, string tituloIncidente)
    {
        var mensaje = $"Se te ha asignado un nuevo incidente: {tituloIncidente}";
        await _emailService.EnviarNotificacionIncidenteAsync(emailTecnico, tituloIncidente, mensaje);
    }

    public async Task EnviarNotificacionEscalacionAsync(string emailTecnico, string tituloIncidente, string mensaje)
    {
        var mensajeCompleto = $"Incidente escalado: {tituloIncidente}\n\nMensaje: {mensaje}";
        await _emailService.EnviarNotificacionIncidenteAsync(emailTecnico, tituloIncidente, mensajeCompleto);
    }

    public async Task EnviarNotificacionResolucionAsync(string emailUsuario, string tituloIncidente, string resolucion)
    {
        var mensaje = $"Tu incidente ha sido resuelto: {tituloIncidente}\n\nResolución: {resolucion}";
        await _emailService.EnviarNotificacionIncidenteAsync(emailUsuario, tituloIncidente, mensaje);
    }

    public async Task EnviarNotificacionDescartadoAsync(string emailUsuario, string tituloIncidente, string motivo)
    {
        var mensaje = $"Tu incidente ha sido descartado: {tituloIncidente}\n\nMotivo: {motivo}";
        await _emailService.EnviarNotificacionIncidenteAsync(emailUsuario, tituloIncidente, mensaje);
    }
}
