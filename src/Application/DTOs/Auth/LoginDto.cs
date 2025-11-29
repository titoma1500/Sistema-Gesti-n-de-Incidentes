namespace Proyecto.Application.DTOs.Auth;

public class LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginResponseDto
{
    public int UsuarioId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Nivel { get; set; }
    public string Token { get; set; } = string.Empty; // JWT si usas
}