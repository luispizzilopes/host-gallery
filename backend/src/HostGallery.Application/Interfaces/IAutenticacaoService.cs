using HostGallery.Application.Identity.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HostGallery.Application.Identity.Intefaces; 

public interface IAutenticacaoService
{
    Task<InformacoesUsuarioDTO> Login(LoginDTO login);
    //Task<bool> RedefinirSenha(RedefinirSenhaDTO redefinirSenha);
    Task<bool> CadastroUsuario(CadastroUsuarioDTO cadastroUsuario);
    Task<ContentResult> ConfirmarEmail(string userId, string token); 
}
