using HostGallery.Application.Interfaces;
using HostGallery.Application.Mappings;
using HostGallery.Application.Services;
using HostGallery.Domain.Interfaces;
using HostGallery.Infrastructure.Context;
using HostGallery.Infrastructure.Identity.Entities;
using HostGallery.Infrastructure.Identity.Intefaces;
using HostGallery.Infrastructure.Identity.Services;
using HostGallery.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HostGallery.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjectionAPI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor(); 

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentity<Usuario, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders(); 

        services.AddScoped<ICategoriaRepository, CategoriaRepository>(); 
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IEventoRepository, EventoRepository>(); 

        services.AddScoped<ICategoriaService, CategoriaService>(); 
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IEventoService, EventoService>(); 
        services.AddScoped<IAutenticacaoService, AutenticacaoService>();
        services.AddScoped<IUsuarioService, UsuarioService>(); 

        /*
         JWT - Adiciona o manipulador de autenticação e define o 
         esquema de autenticação usando : Bearer
         valida o emissor, a audiencia e a chave 
         usando a chave secreta valida a assinatura
        */
        services.AddAuthentication(
         JwtBearerDefaults.AuthenticationScheme).
         AddJwtBearer(options =>
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidAudience = configuration["TokenConfiguration:Audience"],
             ValidIssuer = configuration["TokenConfiguration:Issuer"],
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]!))
         });

        services.AddAutoMapper(typeof(ProfileMapping));

        return services; 
    }
}
