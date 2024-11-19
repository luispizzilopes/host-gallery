using HostGallery.Application.Identity.Dtos;

namespace HostGallery.Infrastructure.Identity.Intefaces; 

public interface IUsuarioService
{
    Task<UsuarioDTO> BuscarUsuario(string id);
    Task<IEnumerable<UsuarioDTO>> BuscarUsuarios(); 
}
