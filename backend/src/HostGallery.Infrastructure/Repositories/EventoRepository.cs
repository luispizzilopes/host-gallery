﻿using HostGallery.Domain.Entities;
using HostGallery.Domain.Interfaces;
using HostGallery.Infrastructure.Context;
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

    public async Task<IEnumerable<Evento>> BuscarEventos()
    {
        return await _context.Eventos
            .AsNoTracking()
            .ToListAsync(); 
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