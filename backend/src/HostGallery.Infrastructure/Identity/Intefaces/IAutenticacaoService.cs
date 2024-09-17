﻿using HostGallery.Infrastructure.Identity.Dtos;

namespace HostGallery.Infrastructure.Identity.Intefaces; 

public interface IAutenticacaoService
{
    Task<InformacoesUsuarioDTO> Login(LoginDTO login);
    //Task<bool> RedefinirSenha(RedefinirSenhaDTO redefinirSenha);
    Task<bool> CadastroUsuario(CadastroUsuarioDTO cadastroUsuario); 
}