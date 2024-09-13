using HostGallery.Domain.Common;

namespace HostGallery.Domain.Entities;

public class Categoria : EntidadeBase
{
    public string Nome { get; set; } = null!; 
    public string? Descricao { get; set; } 
    public bool Publico { get; set; }

    //Propriedades de relacionamento e navegação
    public string UsuarioId { get; set; } = null!;
    public ICollection<Item>? Itens { get; set; }
}
