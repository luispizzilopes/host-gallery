using Microsoft.AspNetCore.Identity;

namespace HostGallery.Domain.Entities;

public class Usuario : IdentityUser
{
    public string? FotoPerfil { get; set; }
    public string PrimeiroNome { get; set; } = null!;
    public string? UltimoNome { get; set; } = null!;

    // Propriedades de relacionamento e navegação
    public ICollection<Categoria>? Categorias { get; set; }
    public ICollection<Item>? Itens { get; set; }
    public ICollection<Evento>? Eventos { get; set; }
    public ICollection<EventoUsuario>? EventosUsuarios { get; set; }
}
