namespace HostGallery.Domain.Common;

public class ParametrosPaginacao
{
    public int NumeroPagina { get; set; } = 1;
    public int TamanhoPagina { get; set; } = 10;

    public int TamanhoMaximo { get; set; } = 50;

    public int TamanhoFinal =>
        TamanhoPagina > TamanhoMaximo ? TamanhoMaximo : TamanhoPagina;
}
