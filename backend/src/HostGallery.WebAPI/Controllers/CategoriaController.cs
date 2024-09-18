using HostGallery.Application.Dtos.Categoria;
using HostGallery.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HostGallery.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _CategoriaService;

        public CategoriaController(ICategoriaService CategoriaService)
        {
            _CategoriaService = CategoriaService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> BuscarCategoria([FromRoute] int id)
        {
            var resposta = await _CategoriaService.BuscarCategoria(id);
            return Ok(resposta);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> BuscarCategoria()
        {
            var resposta = await _CategoriaService.BuscarCategorias();
            return Ok(resposta);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> AdicionarCategoria([FromBody] CategoriaDTO Categoria)
        {
            var resposta = await _CategoriaService.AdicionarCategoria(Categoria);
            return Created(HttpStatusCode.Created.ToString(), resposta);
        }

        [HttpPut]
        public async Task<ActionResult<CategoriaDTO>> AtualizarCategoria([FromBody] CategoriaDTO Categoria)
        {
            var resposta = await _CategoriaService.AtualizarCategoria(Categoria);
            return Ok(resposta);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletarCategoria([FromRoute] int id)
        {
            var resposta = await _CategoriaService.DeletarCategoria(id);

            if (resposta)
            {
                return Ok("Categoria deletada com sucesso.");
            }

            return BadRequest("Erro ao deletar a Categoria.");
        }
    }
}
