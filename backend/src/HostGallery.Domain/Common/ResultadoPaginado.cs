namespace HostGallery.Domain.Common;
public class ResultadoPaginado<T>
{
    public List<T>? Dados { get; set; }
    public int TotalRegistros { get; set; }
    public int NumeroPagina { get; set; }
    public int TamanhoPagina { get; set; }
    public int TotalPaginas => (int)Math.Ceiling((double)TotalRegistros / TamanhoPagina);
}
