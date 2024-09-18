using HostGallery.Application.Dtos.Common;

namespace HostGallery.Application.Dtos.Item; 

public class ItemDTO : EntidadeBaseDTO
{
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public byte[] Arquivo { get; set; } = null!;
    public string UsuarioId { get; set; } = null!;
    public int CategoriaId { get; set; }
}
