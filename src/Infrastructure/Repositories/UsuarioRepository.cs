using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities;
using Proyecto.Infrastructure.Data;

namespace Proyecto.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ObtenerPorIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario?> ObtenerPorEmailAsync(string email)
    {
        return await _context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email && u.Activo);
    }

    public async Task<IEnumerable<Usuario>> ObtenerPorNivelAsync(int nivel)
    {
        return await _context.Usuarios
            .AsNoTracking()
            .Where(u => (int)u.Nivel == nivel && u.Activo)
            .ToListAsync();
    }

    public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
    {
        return await _context.Usuarios
            .Where(u => u.Activo)
            .OrderBy(u => u.Nombre)
            .ToListAsync();
    }

    public async Task<Usuario> CrearAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task ActualizarAsync(Usuario usuario)
    {
        _context.Entry(usuario).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
