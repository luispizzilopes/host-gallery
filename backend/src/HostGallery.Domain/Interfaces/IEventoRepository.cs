using HostGallery.Domain.Common;
using HostGallery.Domain.Entities;

namespace HostGallery.Domain.Interfaces; 

public interface IEventoRepository
{
    Task<ResultadoPaginado<Evento>> BuscarEventosUsuario(string usuarioId, ParametrosPaginacao parametrosPaginacao);
    Task<Evento> BuscarEvento(int id);
    Task<Evento> AdicionarEvento(Evento evento);
    Task<Evento> AtualizarEvento(Evento evento);
    Task<bool> DeletarEvento(Evento evento);
}
