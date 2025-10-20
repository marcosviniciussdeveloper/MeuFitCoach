using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Application.Dtos
{
    public class CriarPlanoDeTreinoDto
    {
        
        public string NomePlano { get; set; }
        public string Descricao { get; set; }
        public bool PlanoAtivo { get; set; }
        public Guid UsuarioId { get; set; } = Guid.Empty;
    }

    public class PlanoDeTreinoResponseDto
    {
        public string NomePlano { get; private set; }

        public string Descricao { get; private set; }

        public bool PlanoAtivo { get; private set; }

        public Guid UsuarioId { get; private set; }

    }
}
