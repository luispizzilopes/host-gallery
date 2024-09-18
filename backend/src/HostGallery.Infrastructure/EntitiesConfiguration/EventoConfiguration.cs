using HostGallery.Domain.Entities;
using HostGallery.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostGallery.Infrastructure.EntitiesConfiguration
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.Ignore(e => e.Usuarios); 

            builder.HasMany<Usuario>()
             .WithMany()
             .UsingEntity<Dictionary<string, object>>(
                 "EventosUsuarios",
                 j => j
                     .HasOne<Usuario>()
                     .WithMany()
                     .HasForeignKey("UsuarioId"),
                 j => j
                     .HasOne<Evento>()
                     .WithMany()
                     .HasForeignKey("EventoId"));
        }
    }
}
