using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Application.Interface.Persistence
{
    public  interface IUsuarioRepository
    {
        Task  AddUsuarioAsync(Usuario NovoUsuario);
        Task<Usuario> GetByIdUsuarioAsync(Guid UsuarioId);
        Task<Usuario> GetByEmailUsuarioAsync(string email);
        Task<List<Usuario>> ListarUsuariosAsync();
        Task  AtualizarUsuarioAsync(Usuario usuario);
        Task<Usuario> GeyByIdNumeroWhatsappAsync (string numeroWhatsapp);

    }
}
