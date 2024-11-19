using AutoMapper;
using HostGallery.Application.Dtos.Evento;
using HostGallery.Application.Interfaces;
using HostGallery.Application.Utils;
using HostGallery.Domain.Common;
using HostGallery.Domain.Entities;
using HostGallery.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

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

    public async Task<ResultadoPaginado<EventoDTO>> BuscarEventos(ParametrosPaginacao parametrosPaginacao)
    {
        var usuarioId = _httpContextAccessor.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value;
        if (usuarioId == null) return new ResultadoPaginado<EventoDTO>();

        var paginacaoResultado = await _repositoryEvento.BuscarEventosUsuario(usuarioId, parametrosPaginacao);
        var paginacaoResultadoDto = ConverterResultadoPaginadoParaDataTransferObject<Evento, EventoDTO>.ConverterResultado(paginacaoResultado, _mapper);

        return paginacaoResultadoDto; 
    }

    public async Task<EventoDTO> AdicionarEvento(EventoDTO evento)
    {
        var entidade = _mapper.Map<Evento>(evento);

        entidade.IpCriacao = _httpContextAccessor.HttpContext?.Request.Headers["IpCliente"].FirstOrDefault();
        entidade.DataCriacao = DateTimeOffset.UtcNow;
        entidade.CodigoConvite = Guid.NewGuid();

        return _mapper.Map<EventoDTO>(await _repositoryEvento.AdicionarEvento(entidade)); 
    }

    public async Task<EventoDTO> AtualizarEvento(EventoDTO evento)
    {
        var entidade = _mapper.Map<Evento>(evento);

        entidade.IpAtualizacao = _httpContextAccessor.HttpContext?.Request.Headers["IpCliente"].FirstOrDefault();
        entidade.DataAtualizacao = DateTimeOffset.UtcNow;

        return _mapper.Map<EventoDTO>(await _repositoryEvento.AtualizarEvento(entidade));
    }

    public async Task<bool> DeletarEvento(int id)
    {
        var entidade = await _repositoryEvento.BuscarEvento(id);

        return await _repositoryEvento.DeletarEvento(entidade);
    }
}
