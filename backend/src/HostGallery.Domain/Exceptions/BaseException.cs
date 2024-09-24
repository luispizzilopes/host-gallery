namespace HostGallery.Domain.Exceptions; 

public class BaseException : Exception
{
    public BaseException(string mensagem) : base(mensagem) { }
}
