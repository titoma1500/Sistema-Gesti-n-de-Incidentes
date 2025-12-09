namespace Proyecto.Application.Interfaces
{
    public interface INotificacionService
    {
        Task AgregarNotificacion(int usuarioId, string mensaje, string tipo);
        Task<List<Notificacion>> ObtenerNotificaciones(int usuarioId);
        Task MarcarComoLeida(int notificacionId);
        Task MarcarTodasComoLeidas(int usuarioId);
        Task<int> ObtenerNoLeidas(int usuarioId);
    }

    public class Notificacion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public string Tipo { get; set; } = "info"; // info, success, warning, danger
        public DateTime Fecha { get; set; }
        public bool Leida { get; set; }
    }
}
