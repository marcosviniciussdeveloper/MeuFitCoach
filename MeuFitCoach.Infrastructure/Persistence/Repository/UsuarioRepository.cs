

using MeuFitCoach.Application.Interface.Persistence;
using MeuFitCoach.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class UsuarioRepository: IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Guid> AddUsuarioAsync(Usuario NovoUsuario)
    {
         _context .Usuario.Add(NovoUsuario);
        await _context.SaveChangesAsync();
        return NovoUsuario.Id;
    }


    public async Task<bool> AtualizarUsuarioAsync(Usuario AtualizarUsuario)
    {
      _context.Usuario.Update(AtualizarUsuario);
       var resultado = await _context.SaveChangesAsync();

        return  resultado> 0;
    }

    public async  Task<bool> DeleteUsuarioAsync(Guid UsuarioId)
    {
        _context.Usuario.Remove(new Usuario { Id = UsuarioId });
        var resultado = await _context.SaveChangesAsync();
    
        return resultado > 0;

    }


    public async Task<Usuario> GetByIdUsuarioAsync(Guid UsuarioId)
    {
         return await _context.Usuario
            .FirstOrDefaultAsync(u => u.Id == UsuarioId) 
            ?? throw new KeyNotFoundException($"Usuario with Id {UsuarioId} not found.");
    }

    public async Task<Usuario> GeyByIdNumeroWhatsappAsync(string numeroWhatsapp)
    {
         return await _context.Usuario
            .FirstOrDefaultAsync(u => u.NumeroWhatsapp == numeroWhatsapp) 
            ?? throw new KeyNotFoundException($"Usuario with Whatsapp {numeroWhatsapp} not found.");
    }

    public async Task<List<Usuario>> ListarUsuariosAsync(Usuario ListarUsuarios)
    {
        var todoUsuarios = await _context.Usuario.ToListAsync();
        return todoUsuarios;

    }
}
