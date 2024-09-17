namespace HostGallery.Infrastructure.Identity.Exceptions; 

public class CredenciaisInvalidasException : Exception
{
    public CredenciaisInvalidasException() : base("As credenciais fornecidas são inválidas.") { }
}
