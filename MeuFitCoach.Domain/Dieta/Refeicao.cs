using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Domain.Dieta
{
    public class Refeicao
    {
        public Guid id { get; set; }
        public string  NomeRefeicao {get; set;} 
        public double calorias { get; set;}
         

    }
}
