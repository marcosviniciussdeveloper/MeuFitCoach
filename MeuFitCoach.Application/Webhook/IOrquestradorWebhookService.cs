using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Application.Webhook
{
    public interface IOrquestradorWebhookService
    {
        Task<string> ProcessarMensagemAsync(string numerodeTelefone , string mensagemRecebida);
    }
}
