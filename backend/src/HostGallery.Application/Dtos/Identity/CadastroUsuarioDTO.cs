using System.ComponentModel.DataAnnotations;

namespace HostGallery.Application.Identity.Dtos; 

public class CadastroUsuarioDTO
{
    [EmailAddress]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    public string Senha { get; set; } = null!;

    [MaxLength(100)]
    public string Apelido { get; set; } = null!;

    [MaxLength(100)]
    public string PrimeiroNome { get; set; } = null!;

    [MaxLength(100)]
    public string UltimoNome { get; set; } = null!;
}
