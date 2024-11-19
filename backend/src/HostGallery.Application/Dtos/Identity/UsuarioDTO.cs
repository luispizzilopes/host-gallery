using HostGallery.Domain.Entities;

namespace HostGallery.Application.Identity.Dtos; 

public class UsuarioDTO
{
    public string Nome { get; set; } = null!;
    public string UserName { get; set; } = null!; 
    public string Email { get; set; } = null!;
    public string? FotoPerfil { get; set; }

    public static UsuarioDTO ConverterParaDataTransferObject(Usuario entidade)
    {
        return new UsuarioDTO
        {
            Nome = $"{entidade.PrimeiroNome} {entidade.UltimoNome}",
            Email = entidade.Email!,
            FotoPerfil = entidade.FotoPerfil,
            UserName = entidade.UserName!
        }; 
    }
}
