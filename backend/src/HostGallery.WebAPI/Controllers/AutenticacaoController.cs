﻿using HostGallery.Application.Identity.Dtos;
using HostGallery.Application.Identity.Intefaces;
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

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginDTO login)
    {
        var resposta = await _autenticacaoService.Login(login);

        if (resposta is not null)
        {
            return Ok(resposta);
        }

        return Unauthorized();
    }

    [HttpPost("adicionar-conta")]
    public async Task<ActionResult> CadastroUsuario([FromBody] CadastroUsuarioDTO cadastroUsuario)
    {
        var resposta = await _autenticacaoService.CadastroUsuario(cadastroUsuario);

        if (resposta)
        {
            return Ok(resposta); 
        }

        return BadRequest(resposta); 
    }

    [HttpGet("confirmar-email")]
    public async Task<ContentResult> ConfirmarEmail([FromQuery] string userId, [FromQuery] string token)
    {
        var resposta = await _autenticacaoService.ConfirmarEmail(userId, token);

        return resposta; 
    }
}
