using AutoMapper;
using HostGallery.Application.Dtos.Categoria;
using HostGallery.Application.Interfaces;
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

    public async Task<IEnumerable<CategoriaDTO>> BuscarCategorias()
    {
        var entidades = await _repositoryCategoria.BuscarCategorias();

        return _mapper.Map<IEnumerable<CategoriaDTO>>(entidades); 
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
