using Proyecto.Application.DTOs.Auth;

namespace Proyecto.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);
    Task<bool> ValidarCredencialesAsync(string email, string password);
}