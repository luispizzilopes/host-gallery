using HostGallery.Infrastructure.Context;
using HostGallery.Infrastructure.Identity.Dtos;
using HostGallery.Infrastructure.Identity.Entities;
using HostGallery.Infrastructure.Identity.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace HostGallery.Infrastructure.Identity.Services;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _context; 

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UsuarioDTO> BuscarUsuario(string id)
    {
        var entidade = await _context.Users
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync() 
        ?? throw new KeyNotFoundException($"Usuário com ID {id} não encontrado.");

        return Usuario.ObterDataTransferObject(entidade);
    }

    public async Task<IEnumerable<UsuarioDTO>> BuscarUsuarios()
    {
        var entidades = await _context.Users
            .AsNoTracking()
            .ToListAsync();

        return entidades.Select(entidade => Usuario.ObterDataTransferObject(entidade));
    }
}
