namespace HostGallery.Application.Dtos.Categoria; 

public class CategoriaDTO
{
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public bool Publico { get; set; }
    public string UsuarioId { get; set; } = null!;
}
