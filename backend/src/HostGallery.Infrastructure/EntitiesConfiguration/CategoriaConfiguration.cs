using HostGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostGallery.Infrastructure.EntitiesConfiguration;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Descricao)
            .HasMaxLength(1000);

        builder.HasMany(c => c.Itens)
            .WithOne(c => c.Categoria)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); 
    }
}
