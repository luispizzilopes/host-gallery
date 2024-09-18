using AutoMapper;
using HostGallery.Application.Dtos.Evento;
using HostGallery.Application.Interfaces;
using HostGallery.Domain.Entities;
using HostGallery.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Xml.Serialization;

namespace HostGallery.Application.Services; 

public class EventoService : IEventoService
{
    private readonly IEventoRepository _repositoryEvento;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EventoService(IEventoRepository repositoryEvento, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _repositoryEvento = repositoryEvento;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<EventoDTO> BuscarEvento(int id)
    {
        var entidade = await _repositoryEvento.BuscarEvento(id);

        return _mapper.Map<EventoDTO>(entidade); 
    }

    public async Task<IEnumerable<EventoDTO>> BuscarEventos()
    {
        var entidades = await _repositoryEvento.BuscarEventos();

        return _mapper.Map<IEnumerable<EventoDTO>>(entidades); 
    }

    public async Task<EventoDTO> AdicionarEvento(EventoDTO evento)
    {
        var entidade = _mapper.Map<Evento>(evento);

        entidade.IpCriacao = _httpContextAccessor.HttpContext.Request.Headers["IpCliente"].FirstOrDefault();
        entidade.DataCriacao = DateTimeOffset.UtcNow;
        entidade.CodigoConvite = Guid.NewGuid();

        return _mapper.Map<EventoDTO>(await _repositoryEvento.AdicionarEvento(entidade)); 
    }

    public async Task<EventoDTO> AtualizarEvento(EventoDTO evento)
    {
        var entidade = _mapper.Map<Evento>(evento);

        entidade.IpAtualizacao = _httpContextAccessor.HttpContext.Request.Headers["IpCliente"].FirstOrDefault();
        entidade.DataAtualizacao = DateTimeOffset.UtcNow;

        return _mapper.Map<EventoDTO>(await _repositoryEvento.AtualizarEvento(entidade));
    }

    public async Task<bool> DeletarEvento(int id)
    {
        var entidade = await _repositoryEvento.BuscarEvento(id);

        return await _repositoryEvento.DeletarEvento(entidade);
    }
}
