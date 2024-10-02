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
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace HostGallery.Infrastructure.Identity.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor; 
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AutenticacaoService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IHttpContextAccessor httpContextAccessor, AppDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> CadastroUsuario(CadastroUsuarioDTO cadastroUsuario)
        {
            var usuario = new Usuario
            {
                UserName = cadastroUsuario.Apelido,
                Email = cadastroUsuario.Email,
                PrimeiroNome = cadastroUsuario.PrimeiroNome,
                UltimoNome = cadastroUsuario.UltimoNome,
                EmailConfirmed = false, 
            };

            var resultado = await _userManager.CreateAsync(usuario, cadastroUsuario.Senha);

            if (resultado.Succeeded)
            {
                await EnviarConfirmacaoEmailCadastroUsuario(cadastroUsuario.Email); 
            }

            return resultado.Succeeded;
        }

        private async Task EnviarConfirmacaoEmailCadastroUsuario(string email)
        {
            string emailDoRemetente = "sistema.extendfile@gmail.com";
            string senhaDoApp = "gdtvspmzugqokbpb";

            var mensagem = new MailMessage();

            mensagem.From = new MailAddress(emailDoRemetente);
            mensagem.To.Add(email);
            mensagem.Subject = "Confirmação de Email - Host Gallery";
            mensagem.Body = await ObterTemplateConfirmacaoEmail(email);
            mensagem.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(emailDoRemetente, senhaDoApp);
            smtp.EnableSsl = true;

            await smtp.SendMailAsync(mensagem);
        }

        private async Task<string> ObterTemplateConfirmacaoEmail(string email)
        {
            var caminhoTemplates = Path.Combine(
            [
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "Templates"
            ]);

            var caminhoArquivo = Path.Combine(caminhoTemplates, "TemplateConfirmacaoEmail.html");

            if (File.Exists(caminhoArquivo))
            {
                string linkConfirmacao = await GerarTokenConfirmacaoEmail(email); 

                string conteudoTemplate = File.ReadAllText(caminhoArquivo);
                return conteudoTemplate
                    .Replace("{email}", email)
                    .Replace("{linkConfirmacao}", linkConfirmacao);
            }

            throw new FileNotFoundException($"O arquivo não foi encontrado.");
        }

        private async Task<string> GerarTokenConfirmacaoEmail(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);

            if (usuario is null)
            {
                throw new InvalidOperationException("Usuário não encontrado com o ID fornecido.");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);

            var linkConfirmacao = $"{_httpContextAccessor.HttpContext!.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/api/Autenticacao/confirmar-email?userId={usuario.Id}&token={Uri.EscapeDataString(token)}";

            return linkConfirmacao; 
        }

        public async Task<InformacoesUsuarioDTO> Login(LoginDTO login)
        {
            await VerificarEmailOuUsername(login); 

            var resultado = await _signInManager.PasswordSignInAsync(login.Email, login.Senha, false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                var informacoesUsuarioLogado = await GerarInformacoesUsuarioLogado(login.Email);

                return informacoesUsuarioLogado; 
            }

            throw new CredenciaisInvalidasException(); 
        }

        private async Task VerificarEmailOuUsername(LoginDTO login)
        {
            if (EmailValido(login.Email))
            {
                var usuario = await _userManager.FindByEmailAsync(login.Email);

                if (usuario is null)
                {
                    throw new InvalidOperationException("Usuário não encontrado com o email fornecido.");
                }

                login.Email = usuario.UserName!; 
            }
        }

        private bool EmailValido(string email)
        {
            string padrao = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, padrao);
        }

        private async Task<InformacoesUsuarioDTO> GerarInformacoesUsuarioLogado(string userName)
        {
            var usuario = await _context.Users
                 .Where(u => u.UserName == userName)
                 .FirstOrDefaultAsync();

            InformacoesTokenDTO informacoesTokenUsuario = GerarTokenAutenticacaoJwt(usuario!);

            return new InformacoesUsuarioDTO
            {
                Email = usuario?.Email!,
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

        public async Task<ContentResult> ConfirmarEmail(string userId, string token)
        {
            var usuario = await _userManager.FindByIdAsync(userId);

            if (usuario is null)
            {
                throw new InvalidOperationException("Usuário não encontrado com o ID fornecido.");
            }

            var resultado = await _userManager.ConfirmEmailAsync(usuario, token);

            var caminhoTemplates = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "Templates"
            );

            string conteudo;
            if (resultado.Succeeded)
            {
                var caminhoArquivoSucesso = Path.Combine(caminhoTemplates, "TemplateEmailConfirmado.html");
                conteudo = File.ReadAllText(caminhoArquivoSucesso);
                return new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Content = conteudo,
                    ContentType = "text/html"
                };
            }
            else
            {
                var caminhoArquivoErro = Path.Combine(caminhoTemplates, "TemplateConfirmacaoEmailErro.html");
                conteudo = File.ReadAllText(caminhoArquivoErro);
                return new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = conteudo,
                    ContentType = "text/html"
                };
            }
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
