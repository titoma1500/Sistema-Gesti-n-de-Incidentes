using Proyecto.Application.DTOs.Auth;
using Proyecto.Application.Interfaces;
using Microsoft.JSInterop;
using Proyecto.Infrastructure.Services;
using System.Text.Json;
using System.Collections.Concurrent;

namespace Proyecto.Application.Services;

public class SessionService : ISessionService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly CircuitIdProvider _circuitIdProvider;
    private static readonly ConcurrentDictionary<string, UsuarioResponseDto> _sessionCache = new();
    
    // Obtener identificador único por circuito (sesión de usuario en Blazor Server)
    private string CurrentCircuitId => _circuitIdProvider.CircuitId;

    public SessionService(IJSRuntime jsRuntime, CircuitIdProvider circuitIdProvider)
    {
        _jsRuntime = jsRuntime;
        _circuitIdProvider = circuitIdProvider;
    }

    public async Task SetUsuarioActualAsync(UsuarioResponseDto usuario)
    {
        var circuitId = CurrentCircuitId;
        Console.WriteLine($"[SessionService] SetUsuarioActualAsync - CircuitId: {circuitId}, Usuario: {usuario.Email}");
        _sessionCache[circuitId] = usuario;
        
        // Guardar en sessionStorage del navegador
        try
        {
            var json = JsonSerializer.Serialize(usuario);
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "usuario", json);
        }
        catch (InvalidOperationException)
        {
            // Ignorar si JS no está disponible (prerendering)
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SessionService] Error guardando en sessionStorage: {ex.Message}");
        }
    }

    public async Task<UsuarioResponseDto?> GetUsuarioActualAsync()
    {
        var circuitId = CurrentCircuitId;
        
        // Primero verificar cache en memoria
        if (_sessionCache.TryGetValue(circuitId, out var usuario))
        {
            // Console.WriteLine($"[SessionService] GetUsuarioActualAsync (from cache) - CircuitId: {circuitId}, Usuario: {usuario.Email}");
            return usuario;
        }

        // Intentar cargar desde sessionStorage
        try
        {
            var json = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "usuario");
            if (!string.IsNullOrEmpty(json))
            {
                usuario = JsonSerializer.Deserialize<UsuarioResponseDto>(json);
                if (usuario != null)
                {
                    _sessionCache[circuitId] = usuario;
                    Console.WriteLine($"[SessionService] GetUsuarioActualAsync (from sessionStorage) - CircuitId: {circuitId}, Usuario: {usuario.Email}");
                    return usuario;
                }
            }
        }
        catch (InvalidOperationException)
        {
            // JS no disponible (prerendering)
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SessionService] Error cargando desde sessionStorage: {ex.Message}");
        }

        // Console.WriteLine($"[SessionService] GetUsuarioActualAsync - No usuario found for CircuitId: {circuitId}");
        return null;
    }

    public void SetUsuarioActual(UsuarioResponseDto usuario)
    {
        var circuitId = CurrentCircuitId;
        Console.WriteLine($"[SessionService] SetUsuarioActual - CircuitId: {circuitId}, Usuario: {usuario.Email}");
        _sessionCache[circuitId] = usuario;
    }

    public UsuarioResponseDto? GetUsuarioActual()
    {
        var circuitId = CurrentCircuitId;
        _sessionCache.TryGetValue(circuitId, out var usuario);
        if (usuario != null)
        {
            Console.WriteLine($"[SessionService] GetUsuarioActual - CircuitId: {circuitId}, Usuario: {usuario.Email}");
        }
        return usuario;
    }

    public async Task ClearUsuarioActualAsync()
    {
        var circuitId = CurrentCircuitId;
        Console.WriteLine($"[SessionService] ClearUsuarioActualAsync - CircuitId: {circuitId}");
        _sessionCache.TryRemove(circuitId, out _);
        
        try
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "usuario");
        }
        catch (InvalidOperationException)
        {
            // Ignorar si JS no está disponible
        }
        catch { }
    }

    public void ClearUsuarioActual()
    {
        var circuitId = CurrentCircuitId;
        Console.WriteLine($"[SessionService] ClearUsuarioActual - CircuitId: {circuitId}");
        _sessionCache.TryRemove(circuitId, out _);
    }

    public bool EstaAutenticado()
    {
        var circuitId = CurrentCircuitId;
        bool autenticado = _sessionCache.ContainsKey(circuitId);
        Console.WriteLine($"[SessionService] EstaAutenticado - CircuitId: {circuitId}, Autenticado: {autenticado}");
        return autenticado;
    }

    public bool TieneNivelMinimo(int nivelMinimo)
    {
        var circuitId = CurrentCircuitId;
        if (!_sessionCache.TryGetValue(circuitId, out var usuario))
        {
            Console.WriteLine($"[SessionService] TieneNivelMinimo - CircuitId: {circuitId}, No usuario found");
            return false;
        }
        bool tieneNivel = usuario.Nivel >= nivelMinimo;
        Console.WriteLine($"[SessionService] TieneNivelMinimo - CircuitId: {circuitId}, Usuario: {usuario.Email}, Nivel: {usuario.Nivel}, NivelMinimo: {nivelMinimo}, Result: {tieneNivel}");
        return tieneNivel;
    }
}
