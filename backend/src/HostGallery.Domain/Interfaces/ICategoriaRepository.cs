using HostGallery.Domain.Common;
using HostGallery.Domain.Entities;

namespace HostGallery.Domain.Interfaces; 

public interface ICategoriaRepository
{
    Task<ResultadoPaginado<Categoria>> BuscarCategorias(ParametrosPaginacao parametros);
    Task<Categoria> BuscarCategoria(int id);
    Task<Categoria> AdicionarCategoria(Categoria categoria);
    Task<Categoria> AtualizarCategoria(Categoria categoria);
    Task<bool> DeletarCategoria(Categoria categoria); 
}
