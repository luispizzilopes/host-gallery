using HostGallery.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HostGallery.Infrastructure.Extensions; 

public static class QueryableExtensions
{
    public static async Task<ResultadoPaginado<T>> PaginarAsync<T>
        (this IQueryable<T> query, 
        ParametrosPaginacao parametros, 
        CancellationToken cancellationToken = default)
    {
        int totalRegistros = await query.CountAsync(cancellationToken); 

        var dados = await query
            .Skip((parametros.NumeroPagina - 1) * parametros.TamanhoFinal)
            .Take(parametros.TamanhoFinal)
            .ToListAsync(cancellationToken);

        return new ResultadoPaginado<T>
        {
            Dados = dados,
            TotalRegistros = totalRegistros,
            NumeroPagina = parametros.NumeroPagina,
            TamanhoPagina = parametros.TamanhoFinal
        };
    }
}
