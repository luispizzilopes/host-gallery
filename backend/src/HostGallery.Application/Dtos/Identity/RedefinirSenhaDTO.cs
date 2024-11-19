using System.ComponentModel.DataAnnotations;

namespace HostGallery.Application.Identity.Dtos; 

public class RedefinirSenhaDTO
{
    [EmailAddress]
    public string Email { get; set; } = null!; 
}
