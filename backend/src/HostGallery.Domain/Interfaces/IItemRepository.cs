using HostGallery.Domain.Entities;

namespace HostGallery.Domain.Interfaces;

public interface IItemRepository
{
    Task<IEnumerable<Item>> BuscarItens();
    Task<Item> BuscarItem(int id);
    Task<Item> AdicionarItem(Item Item);
    Task<Item> AtualizarItem(Item Item);
    Task<bool> DeletarItem(Item Item);
}
