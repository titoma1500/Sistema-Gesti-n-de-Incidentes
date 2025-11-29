namespace Proyecto.Application.DTOs.Auth;

public class UsuarioResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Nivel { get; set; }
    public string NivelNombre { get; set; } = string.Empty;
    public string? Especialidad { get; set; }
}
