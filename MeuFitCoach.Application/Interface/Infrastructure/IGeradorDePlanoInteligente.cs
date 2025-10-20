
using System.Runtime.CompilerServices;
using MeuFitCoach.Domain.Usuarios;

namespace MeuFitCoach.Application.Interface.Infrastructure
{
    public interface IGeradorDePlanoInteligente
    {
        public Task<string> GerarPlanoAsync(Usuario usuario , CancellationToken ct  = default );
        

 

    }

}

