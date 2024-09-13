using HostGallery.Domain.Common;

namespace HostGallery.Domain.Entities;

public class Item : EntidadeBase
{
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public byte[] Arquivo { get; set; } = null!;

    //Propriedades de relacionamento e navegação
    public string UsuarioId { get; set; } = null!;
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}
