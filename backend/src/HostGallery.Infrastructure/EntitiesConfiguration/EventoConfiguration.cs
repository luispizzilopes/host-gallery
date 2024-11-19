using HostGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostGallery.Infrastructure.EntitiesConfiguration
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CodigoConvite)
                .IsRequired();

            builder.HasMany(p => p.Usuarios)
                .WithMany(u => u.Eventos)
                .UsingEntity<EventoUsuario>(
                      l => l.HasOne(u => u.Usuario).WithMany(u => u.EventosUsuarios).HasForeignKey(u => u.UsuarioId),
                      l => l.HasOne(f => f.Evento).WithMany(f => f.EventosUsuarios).HasForeignKey(f => f.EventoId),
                      l => l.HasKey(k => new { k.UsuarioId, k.EventoId })
               );
        }
    }
}
