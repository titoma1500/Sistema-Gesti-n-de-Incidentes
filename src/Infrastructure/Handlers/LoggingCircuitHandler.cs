using Microsoft.AspNetCore.Components.Server.Circuits;

namespace Proyecto.Infrastructure.Handlers;

public class LoggingCircuitHandler : CircuitHandler
{
    private readonly ILogger<LoggingCircuitHandler> _logger;

    public LoggingCircuitHandler(ILogger<LoggingCircuitHandler> logger)
    {
        _logger = logger;
        Console.WriteLine("[CircuitHandler] Constructor llamado");
    }

    public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine($"[Circuit] ✓ Conexión establecida: {circuit.Id}");
            _logger.LogInformation($"[Circuit] Conexión establecida: {circuit.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Circuit ERROR] OnConnectionUpAsync: {ex.Message}");
        }
        return Task.CompletedTask;
    }

    public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine($"[Circuit] ✗ Conexión perdida: {circuit.Id}");
            _logger.LogWarning($"[Circuit] Conexión perdida: {circuit.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Circuit ERROR] OnConnectionDownAsync: {ex.Message}");
        }
        return Task.CompletedTask;
    }

    public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine($"[Circuit] ► Circuito abierto: {circuit.Id}");
            _logger.LogInformation($"[Circuit] Circuito abierto: {circuit.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Circuit ERROR] OnCircuitOpenedAsync: {ex.Message}");
        }
        return Task.CompletedTask;
    }

    public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine($"[Circuit] ◼ Circuito cerrado: {circuit.Id}");
            _logger.LogWarning($"[Circuit] Circuito cerrado: {circuit.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Circuit ERROR] OnCircuitClosedAsync: {ex.Message}");
        }
        return Task.CompletedTask;
    }
}