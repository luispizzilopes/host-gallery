using HostGallery.Domain.Common;
using HostGallery.Domain.Entities;
using HostGallery.Domain.Interfaces;
using HostGallery.Infrastructure.Context;
using HostGallery.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HostGallery.Infrastructure.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly AppDbContext _context; 

    public EventoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Evento> BuscarEvento(int id)
    {
        return await _context.Eventos
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync()
        ?? throw new KeyNotFoundException($"Evento com ID {id} não encontrada.");
    }

    public async Task<ResultadoPaginado<Evento>> BuscarEventosUsuario(string usuarioId, ParametrosPaginacao parametrosPaginacao)
    {
        return await (from t0 in _context.Eventos
                      join t1 in _context.EventosUsuarios on t0.Id equals t1.EventoId
                      where t1.UsuarioId == usuarioId select t0)
                        .AsNoTracking()
                        .AsQueryable()
                        .PaginarAsync(parametrosPaginacao); 
    }

    public async Task<Evento> AdicionarEvento(Evento evento)
    {
        await _context.Eventos.AddAsync(evento);
        await _context.SaveChangesAsync();

        return evento;
    }

    public async Task<Evento> AtualizarEvento(Evento evento)
    {
        _context.Eventos.Update(evento);
        await _context.SaveChangesAsync();

        return evento;
    }

    public async Task<bool> DeletarEvento(Evento evento)
    {
        try
        {
            _context.Remove(evento);
            await _context.SaveChangesAsync();

            return true; 
        }
        catch
        {
            return false; 
        }
    }
}
