using HostGallery.Application.Dtos.Categoria;
using HostGallery.Domain.Common;

namespace HostGallery.Application.Interfaces; 

public interface ICategoriaService
{
    Task<ResultadoPaginado<CategoriaDTO>> BuscarCategorias(ParametrosPaginacao parametrosPaginacao); 
    Task<CategoriaDTO> BuscarCategoria(int id);
    Task<CategoriaDTO> AdicionarCategoria(CategoriaDTO categoria);
    Task<CategoriaDTO> AtualizarCategoria(CategoriaDTO categoria);
    Task<bool> DeletarCategoria(int id); 
}
