using Proyecto.Application.DTOs.Auth;

namespace Proyecto.Application.Interfaces;

public interface IAuthService
{
    Task<UsuarioResponseDto?> LoginAsync(LoginDto loginDto);
    Task<UsuarioResponseDto?> ObtenerUsuarioPorIdAsync(int usuarioId);
    Task<List<UsuarioResponseDto>> ObtenerUsuariosPorNivelMinimoAsync(int nivelMinimo);
    Task<List<UsuarioResponseDto>> ObtenerUsuariosPorNivelAsync(int nivel);
}
