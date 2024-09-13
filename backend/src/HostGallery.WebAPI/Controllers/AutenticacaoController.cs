using HostGallery.Infrastructure.Identity.Dtos;
using HostGallery.Infrastructure.Identity.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace HostGallery.WebAPI.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly IAutenticacaoService _autenticacaoService;

    public AutenticacaoController(IAutenticacaoService autenticacaoService)
    {
        _autenticacaoService = autenticacaoService;
    }

    [HttpPost("adicionar-conta")]
    public async Task<ActionResult> Teste([FromBody] CadastroUsuarioDTO cadastroUsuario)
    {
        var resposta = await _autenticacaoService.CadastroUsuario(cadastroUsuario);

        if (resposta)
        {
            return Ok(resposta); 
        }

        return BadRequest(resposta); 
    }
}
