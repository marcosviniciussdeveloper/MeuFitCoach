using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Application.Interface.Persistence
{
    public interface IPlanoDeTreinoRepository
    {
        Task<PlanoDeTreino> AddPlanoDeTreinoAsync (PlanoDeTreino planoDeTreino);
        Task<PlanoDeTreino> BuscarPorIdAsync (Guid planoDeTreinoId);
        Task<PlanoDeTreino> BuscarPlanoAtivoPorUsuarioIdAsync(Guid planoDeTreinoId);
        Task<PlanoDeTreino> AtualizarPlanoDeTreinoAsync(PlanoDeTreino planoDeTreino);
 
    }
}
