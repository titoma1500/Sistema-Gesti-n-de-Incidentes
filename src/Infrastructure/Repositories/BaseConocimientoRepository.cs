using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities;
using Proyecto.Infrastructure.Data;

namespace Proyecto.Infrastructure.Repositories;

public class BaseConocimientoRepository : IBaseConocimientoRepository
{
    private readonly ApplicationDbContext _context;

    public BaseConocimientoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BaseConocimiento>> ObtenerTodosAsync()
    {
        return await _context.BaseConocimiento
            .Include(b => b.Etiquetas)
            .Include(b => b.CreadoPor)
            .OrderByDescending(b => b.VecesConsultada)
            .ToListAsync();
    }

    public async Task<BaseConocimiento?> ObtenerPorIdAsync(int id)
    {
        return await _context.BaseConocimiento
            .Include(b => b.Etiquetas)
            .Include(b => b.CreadoPor)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<BaseConocimiento>> BuscarPorEtiquetasAsync(List<int> etiquetasIds)
    {
        return await _context.BaseConocimiento
            .Include(b => b.Etiquetas)
            .Include(b => b.CreadoPor)
            .Where(b => b.Etiquetas.Any(e => etiquetasIds.Contains(e.Id)))
            .OrderByDescending(b => b.VecesConsultada)
            .ToListAsync();
    }

    public async Task<IEnumerable<BaseConocimiento>> BuscarPorTextoAsync(string texto)
    {
        return await _context.BaseConocimiento
            .Include(b => b.Etiquetas)
            .Include(b => b.CreadoPor)
            .Where(b => b.Titulo.Contains(texto) || 
                       b.Descripcion.Contains(texto) || 
                       b.Solucion.Contains(texto))
            .OrderByDescending(b => b.VecesConsultada)
            .ToListAsync();
    }

    public async Task<BaseConocimiento> CrearAsync(BaseConocimiento articulo)
    {
        _context.BaseConocimiento.Add(articulo);
        await _context.SaveChangesAsync();
        return articulo;
    }

    public async Task ActualizarAsync(BaseConocimiento articulo)
    {
        articulo.FechaActualizacion = DateTime.Now;
        _context.Entry(articulo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task IncrementarConsultasAsync(int id)
    {
        var articulo = await _context.BaseConocimiento.FindAsync(id);
        if (articulo != null)
        {
            articulo.VecesConsultada++;
            await _context.SaveChangesAsync();
        }
    }
}
