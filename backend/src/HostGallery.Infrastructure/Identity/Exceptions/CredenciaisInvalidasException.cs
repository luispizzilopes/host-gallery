using HostGallery.Domain.Exceptions;

namespace HostGallery.Infrastructure.Identity.Exceptions; 

public class CredenciaisInvalidasException : BaseException
{
    public CredenciaisInvalidasException() : base("As credenciais fornecidas são inválidas.") { }
}
