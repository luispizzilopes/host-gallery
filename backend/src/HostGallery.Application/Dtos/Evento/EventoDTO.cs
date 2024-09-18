using HostGallery.Application.Dtos.Common;

namespace HostGallery.Application.Dtos.Evento; 

public class EventoDTO : EntidadeBaseDTO
{
    public string Nome { get; set; } = null!;
    public string UsuarioId { get; set; } = null!;
    public Guid CodigoConvite { get; set; }
    public DateTimeOffset? DataInicio { get; set; }
    public DateTimeOffset? DataFim { get; set; }
}
