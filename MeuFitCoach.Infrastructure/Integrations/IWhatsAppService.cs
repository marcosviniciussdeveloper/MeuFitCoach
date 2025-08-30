using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Application.Interface.Infrastructure
{
    public  interface IWhatsAppService
    {

        Task  SendMessageAsync(string numeroWhatsapp, string mensagem, string NomeUsuario);

       
        
    }
}
