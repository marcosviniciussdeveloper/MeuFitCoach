using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuFitCoach.Domain.Treino;

namespace MeuFitCoach.Application.Interface.Persistence
{
    public interface IPlanoDeTreinoRepository
    {
        Task<PlanoDeTreino> AddPlanoDeTreinoAsync (PlanoDeTreino planoDeTreino);
        Task<PlanoDeTreino> BuscarPorIdAsync (Guid planoDeTreinoId);
        Task<PlanoDeTreino> BuscarPlanoAtivoPorUsuarioIdAsync(Guid planoDeTreinoId);
        Task<bool> AtualizarPlanoDeTreinoAsync(PlanoDeTreino atualizarplano);

        Task<bool> DeletePlanoDeTreinoAsync(Guid planoDeTreinoId);

    }
}
