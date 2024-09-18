using HostGallery.Domain.Entities;

namespace HostGallery.Domain.Interfaces; 

public interface IEventoRepository
{
    Task<IEnumerable<Evento>> BuscarEventos();
    Task<Evento> BuscarEvento(int id);
    Task<Evento> AdicionarEvento(Evento evento);
    Task<Evento> AtualizarEvento(Evento evento);
    Task<bool> DeletarEvento(Evento evento);
}
