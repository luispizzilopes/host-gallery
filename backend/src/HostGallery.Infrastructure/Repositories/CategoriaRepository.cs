using HostGallery.Domain.Entities;
using HostGallery.Domain.Interfaces;
using HostGallery.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HostGallery.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context; 

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Categoria> BuscarCategoria(int id)
    {
        return await _context.Categorias
                      .Where(c => c.Id == id)
                      .FirstOrDefaultAsync()
        ?? throw new KeyNotFoundException($"Categoria com ID {id} não encontrada.");
    }

    public async Task<IEnumerable<Categoria>> BuscarCategorias()
    {
        return await _context.Categorias.ToListAsync(); 
    }


    public async Task<Categoria> AdicionarCategoria(Categoria categoria)
    {
        await _context.AddAsync(categoria); 
        await _context.SaveChangesAsync();

        return categoria;
    }

    public async Task<Categoria> AtualizarCategoria(Categoria categoria)
    {
        _context.Update(categoria);
        await _context.SaveChangesAsync();

        return categoria; 
    }

    public async Task<bool> DeletarCategoria(Categoria categoria)
    {
        try
        {
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
            
            return true;
        }
        catch
        {
            return false;
        }
    }
}
