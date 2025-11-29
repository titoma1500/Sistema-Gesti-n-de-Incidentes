public interface IUsuarioService
{
    Task<UsuarioDto?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<UsuarioDto>> ObtenerPorNivelAsync(int nivel);
    Task<UsuarioDto?> ObtenerPorEmailAsync(string email);
}