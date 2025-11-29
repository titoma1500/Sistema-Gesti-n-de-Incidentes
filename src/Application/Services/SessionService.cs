using Proyecto.Application.DTOs.Auth;
using Proyecto.Application.Interfaces;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Proyecto.Application.Services;

public class SessionService : ISessionService
{
    private readonly IJSRuntime _jsRuntime;
    private UsuarioResponseDto? _usuarioActual;
    private bool _cargado = false;

    public SessionService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SetUsuarioActualAsync(UsuarioResponseDto usuario)
    {
        _usuarioActual = usuario;
        _cargado = true;
        
        // Guardar en sessionStorage del navegador
        try
        {
            var json = JsonSerializer.Serialize(usuario);
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "usuario", json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SessionService] Error guardando en sessionStorage: {ex.Message}");
        }
    }

    public async Task<UsuarioResponseDto?> GetUsuarioActualAsync()
    {
        if (!_cargado)
        {
            // Intentar cargar desde sessionStorage
            try
            {
                var json = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "usuario");
                if (!string.IsNullOrEmpty(json))
                {
                    _usuarioActual = JsonSerializer.Deserialize<UsuarioResponseDto>(json);
                }
                _cargado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SessionService] Error cargando desde sessionStorage: {ex.Message}");
                _cargado = true;
            }
        }
        return _usuarioActual;
    }

    public void SetUsuarioActual(UsuarioResponseDto usuario)
    {
        _usuarioActual = usuario;
        _cargado = true;
    }

    public UsuarioResponseDto? GetUsuarioActual()
    {
        return _usuarioActual;
    }

    public async Task ClearUsuarioActualAsync()
    {
        _usuarioActual = null;
        _cargado = false;
        
        try
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "usuario");
        }
        catch { }
    }

    public void ClearUsuarioActual()
    {
        _usuarioActual = null;
        _cargado = false;
    }

    public bool EstaAutenticado()
    {
        return _usuarioActual != null;
    }

    public bool TieneNivelMinimo(int nivelMinimo)
    {
        if (_usuarioActual == null) return false;
        return _usuarioActual.Nivel >= nivelMinimo;
    }
}
