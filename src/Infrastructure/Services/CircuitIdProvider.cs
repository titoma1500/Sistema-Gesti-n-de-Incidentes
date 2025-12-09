using Microsoft.AspNetCore.Components.Server.Circuits;

namespace Proyecto.Infrastructure.Services;

/// <summary>
/// Proveedor de Circuit ID para identificar de forma única cada sesión de usuario en Blazor Server
/// </summary>
public class CircuitIdProvider : CircuitHandler
{
    private string? _circuitId;
    
    public string CircuitId
    {
        get
        {
            if (string.IsNullOrEmpty(_circuitId))
            {
                Console.WriteLine("[CircuitIdProvider] WARNING: CircuitId no está disponible, usando fallback");
                return $"fallback_{Guid.NewGuid():N}";
            }
            return _circuitId;
        }
    }

    public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        _circuitId = circuit.Id;
        Console.WriteLine($"[CircuitIdProvider] ✓ Circuit ID capturado: {_circuitId}");
        return base.OnCircuitOpenedAsync(circuit, cancellationToken);
    }

    public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[CircuitIdProvider] ✗ Circuit cerrado: {circuit.Id}");
        _circuitId = null;
        return base.OnCircuitClosedAsync(circuit, cancellationToken);
    }
}
