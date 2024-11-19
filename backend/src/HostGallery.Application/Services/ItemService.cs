using AutoMapper;
using HostGallery.Application.Dtos.Item;
using HostGallery.Application.Interfaces;
using HostGallery.Application.Utils;
using HostGallery.Domain.Common;
using HostGallery.Domain.Entities;
using HostGallery.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace HostGallery.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repositoryItem;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ItemService(IItemRepository repositoryItem, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _repositoryItem = repositoryItem;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ItemDTO> BuscarItem(int id)
    {
        var entidade = await _repositoryItem.BuscarItem(id);

        return _mapper.Map<ItemDTO>(entidade);
    }

    public async Task<ResultadoPaginado<ItemDTO>> BuscarItens(ParametrosPaginacao parametrosPaginacao)
    {
        var resultadoPaginado = await _repositoryItem.BuscarItens(parametrosPaginacao);
        var resultadoPaginadoDto = ConverterResultadoPaginadoParaDataTransferObject<Item, ItemDTO>.ConverterResultado(resultadoPaginado, _mapper); 

        return resultadoPaginadoDto;
    }

    public async Task<ItemDTO> AdicionarItem(ItemDTO item)
    {
        var entidade = _mapper.Map<Item>(item);

        entidade.IpCriacao = _httpContextAccessor.HttpContext?.Request.Headers["IpCliente"].FirstOrDefault();
        entidade.DataCriacao = DateTimeOffset.Now;

        return _mapper.Map<ItemDTO>(await _repositoryItem.AdicionarItem(entidade));
    }

    public async Task<ItemDTO> AtualizarItem(ItemDTO item)
    {
        var entidade = _mapper.Map<Item>(item);

        entidade.IpAtualizacao = _httpContextAccessor.HttpContext?.Request.Headers["IpCliente"].FirstOrDefault();
        entidade.DataAtualizacao = DateTimeOffset.Now;

        return _mapper.Map<ItemDTO>(await _repositoryItem.AtualizarItem(entidade));
    }

    public async Task<bool> DeletarItem(int id)
    {
        var entidade = await _repositoryItem.BuscarItem(id);

        return await _repositoryItem.DeletarItem(entidade);
    }
}
