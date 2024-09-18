using HostGallery.Infrastructure.Identity.Dtos;
using HostGallery.Infrastructure.Identity.Entities;

namespace HostGallery.Infrastructure.Identity.Intefaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> BuscarUsuario(string id);
        Task<IEnumerable<UsuarioDTO>> BuscarUsuarios(); 
    }
}
