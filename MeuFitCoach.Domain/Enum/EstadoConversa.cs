using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Domain.Enum
{
    public enum  EstadoConversa
    {
        Nulo = 0 ,
        AguardandoOpcaoInicial = 1 ,
        AguardandoObjetivo = 2 ,
        AguardandoNivel = 3 ,
        AguardandoEquipamentos = 4 ,
        ProcessandoPlano = 5 ,
        Finalizado =   6 ,
    }
}
