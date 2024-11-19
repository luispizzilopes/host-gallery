using HostGallery.Application.Dtos.Item;
using HostGallery.Domain.Common;

namespace HostGallery.Application.Interfaces;

public interface IItemService
{
    Task<ResultadoPaginado<ItemDTO>> BuscarItens(ParametrosPaginacao parametrosPaginacao);
    Task<ItemDTO> BuscarItem(int id);
    Task<ItemDTO> AdicionarItem(ItemDTO item);
    Task<ItemDTO> AtualizarItem(ItemDTO item);
    Task<bool> DeletarItem(int id);
}
