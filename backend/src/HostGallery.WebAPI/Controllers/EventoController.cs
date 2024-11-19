using HostGallery.Application.Dtos.Evento;
using HostGallery.Application.Interfaces;
using HostGallery.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HostGallery.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EventoDTO>> BuscarEvento([FromRoute] int id)
        {
            var resposta = await _eventoService.BuscarEvento(id);
            return Ok(resposta);
        }

        [HttpGet]
        public async Task<ActionResult<ResultadoPaginado<EventoDTO>>> BuscarEvento([FromQuery] ParametrosPaginacao parametrosPaginacao)
        {
            var resposta = await _eventoService.BuscarEventos(parametrosPaginacao);
            return Ok(resposta);
        }

        [HttpPost]
        public async Task<ActionResult<EventoDTO>> AdicionarEvento([FromBody] EventoDTO evento)
        {
            var resposta = await _eventoService.AdicionarEvento(evento);
            return Created(HttpStatusCode.Created.ToString(), resposta); 
        }

        [HttpPut]
        public async Task<ActionResult<EventoDTO>> AtualizarEvento([FromBody] EventoDTO evento)
        {
            var resposta = await _eventoService.AtualizarEvento(evento);
            return Ok(resposta); 
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletarEvento([FromRoute] int id)
        {
            var resposta = await _eventoService.DeletarEvento(id);

            if (resposta)
            {
                return Ok("Evento deletado com sucesso."); 
            }

            return BadRequest("Erro ao deletar o evento."); 
        }
    }
}
