using HostGallery.Domain.Entities;

namespace HostGallery.Domain.Interfaces; 

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> BuscarCategorias();
    Task<Categoria> BuscarCategoria(int id);
    Task<Categoria> AdicionarCategoria(Categoria categoria);
    Task<Categoria> AtualizarCategoria(Categoria categoria);
    Task<bool> DeletarCategoria(Categoria categoria); 
}
