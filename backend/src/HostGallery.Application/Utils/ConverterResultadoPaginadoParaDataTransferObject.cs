using AutoMapper;
using HostGallery.Domain.Common;

namespace HostGallery.Application.Utils;

internal class ConverterResultadoPaginadoParaDataTransferObject<TOrigem, TDestino>
{
    public static ResultadoPaginado<TDestino> ConverterResultado(ResultadoPaginado<TOrigem> resultadoPaginado, IMapper mapper)
    {
        return new ResultadoPaginado<TDestino>
        {
            Dados = mapper.Map<List<TDestino>>(resultadoPaginado.Dados), 
            NumeroPagina = resultadoPaginado.NumeroPagina,
            TamanhoPagina = resultadoPaginado.TamanhoPagina,
            TotalRegistros = resultadoPaginado.TotalRegistros,
        };
    }
}
