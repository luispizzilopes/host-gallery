using HostGallery.Domain.Entities;
using HostGallery.Infrastructure.Identity.Dtos;
using Microsoft.AspNetCore.Identity;

namespace HostGallery.Infrastructure.Identity.Entities;

public class Usuario : IdentityUser
{
    public string? FotoPerfil { get; set; }
    public string PrimeiroNome { get; set; } = null!;
    public string? UltimoNome { get; set; } = null!;

    public ICollection<Categoria>? Categorias { get; set; }
    public ICollection<Item>? Itens { get; set; }
    public ICollection<Evento>? Eventos { get; set; }

    public static UsuarioDTO ObterDataTransferObject(Usuario usuario)
    {
        return new UsuarioDTO
        {
            Email = usuario.Email!,
            UserName = usuario.UserName!,
            Nome = $"{usuario.PrimeiroNome} {usuario.UltimoNome}",
            FotoPerfil = usuario.FotoPerfil,
        }; 
    }
}
