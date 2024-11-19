using HostGallery.Application.Identity.Dtos;
using HostGallery.Infrastructure.Identity.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HostGallery.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> BuscarUsuarios()
        {
            var resposta = await _usuarioService.BuscarUsuarios();
            return Ok(resposta);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> BuscarUsuario([FromRoute] string id)
        {
            var resposta = await _usuarioService.BuscarUsuario(id);
            return Ok(resposta);
        }
    }
}
