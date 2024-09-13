using HostGallery.Application.Dtos.Item;

namespace HostGallery.Application.Interfaces;

public interface IItemService
{
    Task<IEnumerable<ItemDTO>> BuscarItens();
    Task<ItemDTO> BuscarItem(int id);
    Task<ItemDTO> AdicionarItem(ItemDTO item);
    Task<ItemDTO> AtualizarItem(ItemDTO item);
    Task<bool> DeletarItem(int id);
}
