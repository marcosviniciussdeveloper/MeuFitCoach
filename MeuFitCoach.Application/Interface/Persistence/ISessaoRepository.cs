
using MeuFitCoach.Domain.Usuarios;

//Regras de negocios para uma Sessao de Conversa

namespace MeuFitCoach.Application.Interface.Persistence
{
    
    public interface ISessaoRepository
    {
        Task UpdateAsync (SessaoConversa sessao);

        Task<SessaoConversa> GetById(Guid SessaoId);

    }
}
