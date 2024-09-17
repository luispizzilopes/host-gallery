using HostGallery.Domain.Common;

namespace HostGallery.Domain.Entities;

public class EventoUsuario : EntidadeBase
{
    public int EventoId { get; set; }
    public string UsuarioId { get; set; } = null!; 

    public ICollection<Evento>? Eventos { get; set; }
    public ICollection<string>? Usuarios { get; set; }
}
