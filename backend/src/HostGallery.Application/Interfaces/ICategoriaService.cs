using HostGallery.Application.Dtos.Categoria;

namespace HostGallery.Application.Interfaces; 

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> BuscarCategorias(); 
    Task<CategoriaDTO> BuscarCategoria(int id);
    Task<CategoriaDTO> AdicionarCategoria(CategoriaDTO categoria);
    Task<CategoriaDTO> AtualizarCategoria(CategoriaDTO categoria);
    Task<bool> DeletarCategoria(int id); 
}
