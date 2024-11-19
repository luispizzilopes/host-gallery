using AutoMapper;
using HostGallery.Application.Dtos.Categoria;
using HostGallery.Application.Interfaces;
using HostGallery.Application.Utils;
using HostGallery.Domain.Common;
using HostGallery.Domain.Entities;
using HostGallery.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace HostGallery.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repositoryCategoria;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CategoriaService(ICategoriaRepository repositoryCategoria, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _repositoryCategoria = repositoryCategoria;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<CategoriaDTO> BuscarCategoria(int id)
    {
        var entidade = await _repositoryCategoria.BuscarCategoria(id);

        return _mapper.Map<CategoriaDTO>(entidade); 
    }

    public async Task<ResultadoPaginado<CategoriaDTO>> BuscarCategorias(ParametrosPaginacao parametrosPaginacao)
    {
        var resultadoPaginado = await _repositoryCategoria.BuscarCategorias(parametrosPaginacao);
        var resultadoPaginadoDto = ConverterResultadoPaginadoParaDataTransferObject<Categoria, CategoriaDTO>.ConverterResultado(resultadoPaginado, _mapper);

        return resultadoPaginadoDto; 
    }

    public async Task<CategoriaDTO> AdicionarCategoria(CategoriaDTO categoria)
    {
        var entidade = _mapper.Map<Categoria>(categoria);

        entidade.IpCriacao = _httpContextAccessor.HttpContext?.Request.Headers["IpCliente"].FirstOrDefault();
        entidade.DataCriacao = DateTimeOffset.Now;

        return _mapper.Map<CategoriaDTO>(await _repositoryCategoria.AdicionarCategoria(entidade)); 
    }

    public async Task<CategoriaDTO> AtualizarCategoria(CategoriaDTO categoria)
    {
        var entidade = _mapper.Map<Categoria>(categoria);

        entidade.IpAtualizacao = _httpContextAccessor.HttpContext?.Request.Headers["IpCliente"].FirstOrDefault();
        entidade.DataAtualizacao = DateTimeOffset.Now;

        return _mapper.Map<CategoriaDTO>(await _repositoryCategoria.AtualizarCategoria(entidade));
    }

    public async Task<bool> DeletarCategoria(int id)
    {
        var entidade = await _repositoryCategoria.BuscarCategoria(id);

        return await _repositoryCategoria.DeletarCategoria(entidade); 
    }
}
