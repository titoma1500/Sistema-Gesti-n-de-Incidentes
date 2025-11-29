using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities;
using Proyecto.Infrastructure.Data;

namespace Proyecto.Infrastructure.Repositories;

public class IncidenteRepository : IIncidenteRepository
{
    private readonly ApplicationDbContext _context;

    public IncidenteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Incidente>> ObtenerTodosAsync()
    {
        return await _context.Incidentes
            .Include(i => i.UsuarioReporta)
            .Include(i => i.UsuarioAsignado)
            .Include(i => i.Etiquetas)
            .OrderByDescending(i => i.FechaCreacion)
            .ToListAsync();
    }

    public async Task<Incidente?> ObtenerPorIdAsync(int id)
    {
        return await _context.Incidentes
            .Include(i => i.UsuarioReporta)
            .Include(i => i.UsuarioAsignado)
            .Include(i => i.Etiquetas)
            .Include(i => i.IncidentePadre)
            .Include(i => i.IncidentesEscalados)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Incidente>> ObtenerPorEstadoAsync(int estadoId)
    {
        return await _context.Incidentes
            .Include(i => i.UsuarioReporta)
            .Include(i => i.UsuarioAsignado)
            .Include(i => i.Etiquetas)
            .Where(i => (int)i.Estado == estadoId)
            .OrderByDescending(i => i.FechaCreacion)
            .ToListAsync();
    }

    public async Task<IEnumerable<Incidente>> ObtenerPorUsuarioAsync(int usuarioId)
    {
        return await _context.Incidentes
            .Include(i => i.UsuarioReporta)
            .Include(i => i.UsuarioAsignado)
            .Include(i => i.Etiquetas)
            .Where(i => i.UsuarioReportaId == usuarioId)
            .OrderByDescending(i => i.FechaCreacion)
            .ToListAsync();
    }

    public async Task<IEnumerable<Incidente>> ObtenerPorAsignadoAsync(int usuarioAsignadoId)
    {
        return await _context.Incidentes
            .Include(i => i.UsuarioReporta)
            .Include(i => i.UsuarioAsignado)
            .Include(i => i.Etiquetas)
            .Where(i => i.UsuarioAsignadoId == usuarioAsignadoId)
            .OrderByDescending(i => i.FechaCreacion)
            .ToListAsync();
    }

    public async Task<Incidente> CrearAsync(Incidente incidente)
    {
        _context.Incidentes.Add(incidente);
        await _context.SaveChangesAsync();
        return incidente;
    }

    public async Task ActualizarAsync(Incidente incidente)
    {
        _context.Entry(incidente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var incidente = await _context.Incidentes.FindAsync(id);
        if (incidente != null)
        {
            _context.Incidentes.Remove(incidente);
            await _context.SaveChangesAsync();
        }
    }
}
