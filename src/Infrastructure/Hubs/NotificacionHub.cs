using Microsoft.AspNetCore.SignalR;
using Proyecto.Application.Interfaces;

namespace Proyecto.Infrastructure.Hubs;

public class NotificacionHub : Hub
{
    private readonly INotificacionService _notificacionService;

    public NotificacionHub(INotificacionService notificacionService)
    {
        _notificacionService = notificacionService;
    }

    public async Task EnviarNotificacion(int usuarioId, string mensaje, string tipo)
    {
        await _notificacionService.AgregarNotificacion(usuarioId, mensaje, tipo);
        await Clients.All.SendAsync("RecibirNotificacion", mensaje, tipo);
    }

    public async Task NotificarCambioIncidente(int incidenteId, string accion)
    {
        await Clients.All.SendAsync("ActualizarIncidentes", incidenteId, accion);
    }

    public async Task NotificarAsignacion(int usuarioId, int incidenteId, string titulo)
    {
        var mensaje = $"Se te ha asignado el incidente: {titulo}";
        await EnviarNotificacion(usuarioId, mensaje, "info");
    }

    public async Task NotificarResolucion(int usuarioId, int incidenteId, string titulo)
    {
        var mensaje = $"Tu incidente '{titulo}' ha sido resuelto";
        await EnviarNotificacion(usuarioId, mensaje, "success");
    }

    public async Task NotificarEscalamiento(int usuarioId, int incidenteId, string titulo)
    {
        var mensaje = $"Se te ha asignado el incidente escalado: {titulo}";
        await EnviarNotificacion(usuarioId, mensaje, "warning");
    }

    public async Task NotificarDescarte(int usuarioId, int incidenteId, string titulo, string motivo)
    {
        var mensaje = $"Tu incidente '{titulo}' ha sido descartado. Motivo: {motivo}";
        await EnviarNotificacion(usuarioId, mensaje, "danger");
    }

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"[NotificacionHub] ✓ Cliente conectado - ConnectionId: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"[NotificacionHub] ✗ Cliente desconectado - ConnectionId: {Context.ConnectionId}");
        if (exception != null)
        {
            Console.WriteLine($"[NotificacionHub] Error en desconexión: {exception.Message}");
        }
        await base.OnDisconnectedAsync(exception);
    }
}
