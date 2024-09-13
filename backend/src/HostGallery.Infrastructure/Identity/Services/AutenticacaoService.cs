using HostGallery.Infrastructure.Identity.Dtos;
using HostGallery.Infrastructure.Identity.Entities;
using HostGallery.Infrastructure.Identity.Intefaces;
using Microsoft.AspNetCore.Identity;

namespace HostGallery.Infrastructure.Identity.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public AutenticacaoService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> CadastroUsuario(CadastroUsuarioDTO cadastroUsuario)
        {
            var usuario = new Usuario
            {
                UserName = cadastroUsuario.Email,
                Email = cadastroUsuario.Email,
                PrimeiroNome = cadastroUsuario.PrimeiroNome,
                UltimoNome = cadastroUsuario.UltimoNome,
                EmailConfirmed = false, 
            };

            var resultado = await _userManager.CreateAsync(usuario, cadastroUsuario.Senha);
            return resultado.Succeeded;
        }

        public async Task<bool> Login(LoginDTO login)
        {
            var resultado = await _signInManager.PasswordSignInAsync(login.Email, login.Senha, false, lockoutOnFailure: false);
            return resultado.Succeeded;
        }

        //public async Task<bool> RedefinirSenha(RedefinirSenhaDTO redefinirSenha)
        //{
        //    var usuario = await _userManager.FindByEmailAsync(redefinirSenha.Email);
        //    if (usuario == null)
        //    {
        //        // Usuário não encontrado
        //        return false;
        //    }

        //    var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
        //    var resultado = await _userManager.ResetPasswordAsync(usuario, token, redefinirSenha.NovaSenha);

        //    return resultado.Succeeded;
        //}
    }
}
