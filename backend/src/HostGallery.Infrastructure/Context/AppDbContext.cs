using HostGallery.Domain.Entities;
using HostGallery.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HostGallery.Infrastructure.Context;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<Item> Itens { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext)
            .Assembly);
    }
}
