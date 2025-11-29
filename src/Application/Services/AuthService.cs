using Proyecto.Application.DTOs.Auth;
using Proyecto.Application.Interfaces;
using Proyecto.Infrastructure.Repositories;

namespace Proyecto.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioResponseDto?> LoginAsync(LoginDto loginDto)
    {
        var usuario = await _usuarioRepository.ObtenerPorEmailAsync(loginDto.Email);
        
        if (usuario == null)
            return null;

        // Verificar password (sin hasheo)
        if (usuario.PasswordHash != loginDto.Password)
            return null;

        return new UsuarioResponseDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email,
            Nivel = (int)usuario.Nivel,
            NivelNombre = usuario.Nivel.ToString(),
            Especialidad = usuario.Especialidad
        };
    }

    public async Task<UsuarioResponseDto?> ObtenerUsuarioPorIdAsync(int usuarioId)
    {
        var usuario = await _usuarioRepository.ObtenerPorIdAsync(usuarioId);
        
        if (usuario == null)
            return null;

        return new UsuarioResponseDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email,
            Nivel = (int)usuario.Nivel,
            NivelNombre = usuario.Nivel.ToString(),
            Especialidad = usuario.Especialidad
        };
    }

    public async Task<List<UsuarioResponseDto>> ObtenerUsuariosPorNivelMinimoAsync(int nivelMinimo)
    {
        var usuarios = await _usuarioRepository.ObtenerTodosAsync();
        
        return usuarios
            .Where(u => (int)u.Nivel >= nivelMinimo)
            .Select(u => new UsuarioResponseDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Email,
                Nivel = (int)u.Nivel,
                NivelNombre = u.Nivel.ToString(),
                Especialidad = u.Especialidad
            })
            .ToList();
    }

    public async Task<List<UsuarioResponseDto>> ObtenerUsuariosPorNivelAsync(int nivel)
    {
        var usuarios = await _usuarioRepository.ObtenerTodosAsync();
        
        return usuarios
            .Where(u => (int)u.Nivel == nivel)
            .Select(u => new UsuarioResponseDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Email,
                Nivel = (int)u.Nivel,
                NivelNombre = u.Nivel.ToString(),
                Especialidad = u.Especialidad
            })
            .ToList();
    }
}
