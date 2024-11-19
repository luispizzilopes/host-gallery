using HostGallery.Domain.Common;

namespace HostGallery.Domain.Entities
{
    public class EventoUsuario : EntidadeBase
    {
        public int EventoId { get; set; }
        public string UsuarioId { get; set; } = null!;

        public Evento? Evento { get; set; }
        public Usuario? Usuario { get; set; } 
    }
}
