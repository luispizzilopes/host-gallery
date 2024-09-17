using HostGallery.Infrastructure.Context;
using HostGallery.Infrastructure.Identity.Dtos;
using HostGallery.Infrastructure.Identity.Entities;
using HostGallery.Infrastructure.Identity.Exceptions;
using HostGallery.Infrastructure.Identity.Intefaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HostGallery.Infrastructure.Identity.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AutenticacaoService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, AppDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;
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

        public async Task<InformacoesUsuarioDTO> Login(LoginDTO login)
        {
            var resultado = await _signInManager.PasswordSignInAsync(login.Email, login.Senha, false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                var informacoesUsuarioLogado = await GerarInformacoesUsuarioLogado(login.Email);

                return informacoesUsuarioLogado; 
            }

            throw new CredenciaisInvalidasException(); 
        }

        private async Task<InformacoesUsuarioDTO> GerarInformacoesUsuarioLogado(string email)
        {
            var usuario = await _context.Users
                 .Where(u => u.Email == email)
                 .FirstOrDefaultAsync();

            InformacoesTokenDTO informacoesTokenUsuario = GerarTokenAutenticacaoJwt(usuario!);

            return new InformacoesUsuarioDTO
            {
                Email = email,
                NomeCompleto = $"{usuario?.PrimeiroNome} {usuario?.UltimoNome}",
                ExpiracaoToken = informacoesTokenUsuario.DataExpiracao,
                Token = informacoesTokenUsuario.Token,
            };
        }


        private InformacoesTokenDTO GerarTokenAutenticacaoJwt(Usuario usuario)
        {
            var claims = CriarClaimsUsuario(usuario);
            var credenciais = ObterCredenciais();
            var expiracao = ObterDataExpiracao();

            var token = CriarJwtToken(claims, credenciais, expiracao);

            return CriarInformacoesTokenDto(token, expiracao);
        }

        private Claim[] CriarClaimsUsuario(Usuario usuario)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName!),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Id)
            };
        }

        private SigningCredentials ObterCredenciais()
        {
            var chaveSecreta = Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!);
            var chaveSimetrica = new SymmetricSecurityKey(chaveSecreta);
            return new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256);
        }

        private DateTime ObterDataExpiracao()
        {
            var horasExpiracao = double.Parse(_configuration["TokenConfiguration:ExpireHours"]!);
            return DateTime.Now.AddHours(horasExpiracao);
        }

        private JwtSecurityToken CriarJwtToken(Claim[] claims, SigningCredentials credenciais, DateTime expiracao)
        {
            return new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiracao,
                signingCredentials: credenciais);
        }

        private InformacoesTokenDTO CriarInformacoesTokenDto(JwtSecurityToken token, DateTime expiracao)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            return new InformacoesTokenDTO
            {
                DataExpiracao = expiracao,
                Token = tokenHandler.WriteToken(token)
            };
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
