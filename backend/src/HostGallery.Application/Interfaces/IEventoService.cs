using HostGallery.Application.Dtos.Evento;
using HostGallery.Domain.Common;

namespace HostGallery.Application.Interfaces; 

public interface IEventoService
{
    Task<ResultadoPaginado<EventoDTO>> BuscarEventos(ParametrosPaginacao parametrosPaginacao);
    Task<EventoDTO> BuscarEvento(int id);
    Task<EventoDTO> AdicionarEvento(EventoDTO evento); 
    Task<EventoDTO> AtualizarEvento(EventoDTO evento); 
    Task<bool> DeletarEvento(int id); 
}
