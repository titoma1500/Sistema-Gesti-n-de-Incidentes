using Proyecto.Domain.Entities;

namespace Proyecto.Infrastructure.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> ObtenerPorIdAsync(int id);
    Task<Usuario?> ObtenerPorEmailAsync(string email);
    Task<IEnumerable<Usuario>> ObtenerPorNivelAsync(int nivel);
    Task<IEnumerable<Usuario>> ObtenerTodosAsync();
    Task<Usuario> CrearAsync(Usuario usuario);
    Task ActualizarAsync(Usuario usuario);
}
