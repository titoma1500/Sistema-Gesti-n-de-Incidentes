using Proyecto.Application.Interfaces;

namespace Proyecto.Application.Services
{
    public class NotificacionService : INotificacionService
    {
        private static readonly Dictionary<int, List<Notificacion>> _notificaciones = new();
        private static int _nextId = 1;

        public Task AgregarNotificacion(int usuarioId, string mensaje, string tipo)
        {
            if (!_notificaciones.ContainsKey(usuarioId))
            {
                _notificaciones[usuarioId] = new List<Notificacion>();
            }

            _notificaciones[usuarioId].Add(new Notificacion
            {
                Id = _nextId++,
                UsuarioId = usuarioId,
                Mensaje = mensaje,
                Tipo = tipo,
                Fecha = DateTime.Now,
                Leida = false
            });

            // Mantener solo las últimas 50 notificaciones por usuario
            if (_notificaciones[usuarioId].Count > 50)
            {
                _notificaciones[usuarioId] = _notificaciones[usuarioId]
                    .OrderByDescending(n => n.Fecha)
                    .Take(50)
                    .ToList();
            }

            return Task.CompletedTask;
        }

        public Task<List<Notificacion>> ObtenerNotificaciones(int usuarioId)
        {
            if (!_notificaciones.ContainsKey(usuarioId))
            {
                return Task.FromResult(new List<Notificacion>());
            }

            return Task.FromResult(_notificaciones[usuarioId]
                .OrderByDescending(n => n.Fecha)
                .Take(10)
                .ToList());
        }

        public Task MarcarComoLeida(int notificacionId)
        {
            foreach (var lista in _notificaciones.Values)
            {
                var notificacion = lista.FirstOrDefault(n => n.Id == notificacionId);
                if (notificacion != null)
                {
                    notificacion.Leida = true;
                    break;
                }
            }

            return Task.CompletedTask;
        }

        public Task MarcarTodasComoLeidas(int usuarioId)
        {
            if (_notificaciones.ContainsKey(usuarioId))
            {
                foreach (var notificacion in _notificaciones[usuarioId])
                {
                    notificacion.Leida = true;
                }
            }

            return Task.CompletedTask;
        }

        public Task<int> ObtenerNoLeidas(int usuarioId)
        {
            if (!_notificaciones.ContainsKey(usuarioId))
            {
                return Task.FromResult(0);
            }

            var count = _notificaciones[usuarioId].Count(n => !n.Leida);
            return Task.FromResult(count);
        }
    }
}
