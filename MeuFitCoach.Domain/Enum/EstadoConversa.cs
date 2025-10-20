using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Domain.Enum
{
    public enum  EstadoConversa
    {
        Nulo,
        AguardandoOpcaoInicial,
        AguardandoObjetivo,
        AguardandoNivel,
        AguardandoEquipamentos,
        ProcessandoPlano
    }
}
