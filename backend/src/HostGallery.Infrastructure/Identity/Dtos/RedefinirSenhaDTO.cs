using System.ComponentModel.DataAnnotations;

namespace HostGallery.Infrastructure.Identity.Dtos; 

public class RedefinirSenhaDTO
{
    [EmailAddress]
    public string Email { get; set; } = null!; 
}
