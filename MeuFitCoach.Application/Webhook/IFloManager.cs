using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuFitCoach.Domain.Usuarios;

namespace MeuFitCoach.Application.Webhook
{
    public interface IFlowManager
    {
        Task<string > Processar(Usuario usuario , string mensagemRecebida);



    }
}
