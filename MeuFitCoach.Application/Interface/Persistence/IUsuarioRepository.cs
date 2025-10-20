

using System.Numerics;
using MeuFitCoach.Domain.Usuarios;

namespace MeuFitCoach.Application.Interface.Persistence
{
    //Regras de negocio para criar um usuario 
    public  interface IUsuarioRepository
    {
        Task<Guid>  AddUsuarioAsync(Usuario NovoUsuario);
     
        Task<Usuario> ObterPorNumeroComSessaoAsync(string numeroWhatsapp);

        Task<List<Usuario>> ListarUsuariosAsync(Usuario ListarUsuarios);
        Task<bool>  AtualizarUsuarioAsync(Usuario AtualizarUsuario);
        Task<Usuario> GetByIdNumeroWhatsappAsync (string numeroWhatsapp);

        Task<Usuario> GetByIdAsync(Guid usuarioId);

        Task<bool> DeleteUsuarioAsync(Guid UsuarioId);

    }
}
