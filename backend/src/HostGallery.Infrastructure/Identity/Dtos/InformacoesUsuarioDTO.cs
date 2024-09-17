namespace HostGallery.Infrastructure.Identity.Dtos;

public class InformacoesUsuarioDTO
{
    public string NomeCompleto { get; set; } = null!; 
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
    public DateTime? ExpiracaoToken { get; set; }
}
