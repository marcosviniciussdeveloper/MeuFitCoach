using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Domain
{
    public  class Exercicio
    {
        public Guid Id { get; set; }
        public string NomeExercicio { get; set; }
        public string DescricaoExercicio { get; set; }
        public string IntrucoesExercicio { get; set; }
    }
}
