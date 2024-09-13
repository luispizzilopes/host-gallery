using HostGallery.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostGallery.Infrastructure.EntitiesConfiguration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(u => u.PrimeiroNome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.UltimoNome)
            .HasMaxLength(100);
    }
}
