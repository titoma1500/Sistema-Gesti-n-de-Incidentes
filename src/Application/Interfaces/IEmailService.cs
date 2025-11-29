namespace Proyecto.Application.Interfaces;

public interface IEmailService
{
    Task EnviarNotificacionAsignacionAsync(string emailTecnico, string tituloIncidente);
    Task EnviarNotificacionEscalacionAsync(string emailTecnico, string tituloIncidente, string mensaje);
    Task EnviarNotificacionResolucionAsync(string emailUsuario, string tituloIncidente, string resolucion);
    Task EnviarNotificacionDescartadoAsync(string emailUsuario, string tituloIncidente, string motivo);
}
