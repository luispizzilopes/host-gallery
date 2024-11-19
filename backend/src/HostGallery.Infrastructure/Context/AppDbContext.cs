using HostGallery.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HostGallery.Infrastructure.Context;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<Item> Itens { get; set; }
    public virtual DbSet<Evento> Eventos { get; set; }
    public virtual DbSet<EventoUsuario> EventosUsuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext)
            .Assembly);
    }
}
