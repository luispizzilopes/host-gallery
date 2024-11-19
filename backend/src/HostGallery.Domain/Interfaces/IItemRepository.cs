using HostGallery.Domain.Common;
using HostGallery.Domain.Entities;

namespace HostGallery.Domain.Interfaces;

public interface IItemRepository
{
    Task<ResultadoPaginado<Item>> BuscarItens(ParametrosPaginacao parametrosPaginacao);
    Task<Item> BuscarItem(int id);
    Task<Item> AdicionarItem(Item Item);
    Task<Item> AtualizarItem(Item Item);
    Task<bool> DeletarItem(Item Item);
}
