using Microsoft.EntityFrameworkCore;
using Proyecto.Application.DTOs.Etiqueta;
using Proyecto.Application.Interfaces;
using Proyecto.Infrastructure.Data;

namespace Proyecto.Application.Services;

public class EtiquetaService : IEtiquetaService
{
    private readonly ApplicationDbContext _context;

    public EtiquetaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EtiquetaDto>> ObtenerTodasAsync()
    {
        var etiquetas = await _context.Etiquetas.ToListAsync();
        return etiquetas.Select(e => new EtiquetaDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Categoria = e.Categoria.ToString(),
            Descripcion = e.Descripcion
        });
    }

    public async Task<EtiquetaDto?> ObtenerPorIdAsync(int id)
    {
        var etiqueta = await _context.Etiquetas.FindAsync(id);
        if (etiqueta == null) return null;

        return new EtiquetaDto
        {
            Id = etiqueta.Id,
            Nombre = etiqueta.Nombre,
            Categoria = etiqueta.Categoria.ToString(),
            Descripcion = etiqueta.Descripcion
        };
    }
}
