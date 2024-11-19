using HostGallery.Application.Dtos.Item;
using HostGallery.Application.Interfaces;
using HostGallery.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HostGallery.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _ItemService;

        public ItemController(IItemService ItemService)
        {
            _ItemService = ItemService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemDTO>> BuscarItem([FromRoute] int id)
        {
            var resposta = await _ItemService.BuscarItem(id);
            return Ok(resposta);
        }

        [HttpGet]
        public async Task<ActionResult<ResultadoPaginado<ItemDTO>>> BuscarItem([FromQuery] ParametrosPaginacao parametrosPaginacao)
        {
            var resposta = await _ItemService.BuscarItens(parametrosPaginacao);
            return Ok(resposta);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDTO>> AdicionarItem([FromBody] ItemDTO Item)
        {
            var resposta = await _ItemService.AdicionarItem(Item);
            return Created(HttpStatusCode.Created.ToString(), resposta);
        }

        [HttpPut]
        public async Task<ActionResult<ItemDTO>> AtualizarItem([FromBody] ItemDTO Item)
        {
            var resposta = await _ItemService.AtualizarItem(Item);
            return Ok(resposta);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletarItem([FromRoute] int id)
        {
            var resposta = await _ItemService.DeletarItem(id);

            if (resposta)
            {
                return Ok("Item deletado com sucesso.");
            }

            return BadRequest("Erro ao deletar o Item.");
        }
    }
}
