using Microsoft.AspNetCore.Components.Server.Circuits;

namespace Proyecto.Application.Services;

// Keep minimal lifecycle logging only. Removed global user map/AsyncLocal to avoid race conditions and noisy logs.
public class CircuitHandlerService : CircuitHandler
{
    public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Circuit] Circuito abierto: {circuit.Id}");
        return base.OnCircuitOpenedAsync(circuit, cancellationToken);
    }

    public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Circuit] Circuito cerrado: {circuit.Id}");
        return base.OnCircuitClosedAsync(circuit, cancellationToken);
    }

    public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Circuit] Conexión establecida: {circuit.Id}");
        return base.OnConnectionUpAsync(circuit, cancellationToken);
    }

    public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Circuit] Conexión perdida: {circuit.Id}");
        return base.OnConnectionDownAsync(circuit, cancellationToken);
    }
}
