using HostGallery.Application.Dtos.Evento;

namespace HostGallery.Application.Interfaces; 

public interface IEventoService
{
    Task<IEnumerable<EventoDTO>> BuscarEventos();
    Task<EventoDTO> BuscarEvento(int id);
    Task<EventoDTO> AdicionarEvento(EventoDTO evento); 
    Task<EventoDTO> AtualizarEvento(EventoDTO evento); 
    Task<bool> DeletarEvento(int id); 
}
