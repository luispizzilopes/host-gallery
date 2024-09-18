using HostGallery.Domain.Entities;
using HostGallery.Domain.Interfaces;
using HostGallery.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HostGallery.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Item> BuscarItem(int id)
    {
        return await _context.Itens
                      .Where(c => c.Id == id)
                      .FirstOrDefaultAsync()
        ?? throw new KeyNotFoundException($"Item com ID {id} não encontrada.");
    }

    public async Task<IEnumerable<Item>> BuscarItens()
    {
        return await _context.Itens
            .AsNoTracking()
            .ToListAsync();
    }


    public async Task<Item> AdicionarItem(Item Item)
    {
        await _context.AddAsync(Item);
        await _context.SaveChangesAsync();

        return Item;
    }

    public async Task<Item> AtualizarItem(Item Item)
    {
        _context.Update(Item);
        await _context.SaveChangesAsync();

        return Item;
    }

    public async Task<bool> DeletarItem(Item Item)
    {
        try
        {
            _context.Remove(Item);
            await _context.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }
}
