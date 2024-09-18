namespace HostGallery.Infrastructure.Identity.Dtos
{
    public class UsuarioDTO
    {
        public string Nome { get; set; } = null!;
        public string UserName { get; set; } = null!; 
        public string Email { get; set; } = null!;
        public string? FotoPerfil { get; set; }
    }
}
