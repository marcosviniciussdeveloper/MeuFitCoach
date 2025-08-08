

using System.Numerics;
using MeuFitCoach.Domain.Usuarios;

namespace MeuFitCoach.Application.Interface.Persistence
{
    public  interface IUsuarioRepository
    {
        Task<Guid>  AddUsuarioAsync(Usuario NovoUsuario);
        Task<Usuario> GetByIdUsuarioAsync(Guid UsuarioId);
     
        Task<List<Usuario>> ListarUsuariosAsync(Usuario ListarUsuarios);
        Task<bool>  AtualizarUsuarioAsync(Usuario AtualizarUsuario);
        Task<Usuario> GeyByIdNumeroWhatsappAsync (string numeroWhatsapp);

        Task<bool> DeleteUsuarioAsync(Guid UsuarioId);

    }
}
