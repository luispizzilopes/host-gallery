using HostGallery.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HostGallery.Infrastructure.Identity.Entities;

public class Usuario : IdentityUser
{
    public string PrimeiroNome { get; set; } = null!;
    public string? UltimoNome { get; set; } = null!;

    public ICollection<Categoria>? Categorias { get; set; }
    public ICollection<Item>? Itens { get; set; }
}
