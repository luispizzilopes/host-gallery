using HostGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostGallery.Infrastructure.EntitiesConfiguration; 

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(i => i.Descricao)
            .HasMaxLength(1000);

        builder.Property(i => i.Arquivo)
            .IsRequired(); 
    }
}
