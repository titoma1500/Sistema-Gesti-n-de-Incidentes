using Proyecto.Application.DTOs.Auth;

namespace Proyecto.Application.Interfaces;

public interface ISessionService
{
    Task SetUsuarioActualAsync(UsuarioResponseDto usuario);
    Task<UsuarioResponseDto?> GetUsuarioActualAsync();
    Task ClearUsuarioActualAsync();
    
    // Métodos síncronos para compatibilidad
    void SetUsuarioActual(UsuarioResponseDto usuario);
    UsuarioResponseDto? GetUsuarioActual();
    void ClearUsuarioActual();
    bool EstaAutenticado();
    bool TieneNivelMinimo(int nivelMinimo);
}
