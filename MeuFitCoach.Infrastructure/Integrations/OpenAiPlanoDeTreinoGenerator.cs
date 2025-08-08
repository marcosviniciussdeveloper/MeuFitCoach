



using MeuFitCoach.Application.Interface.Infrastructure;
using MeuFitCoach.Domain.Usuarios;
using Azure.AI.OpenAI;
using OpenAI;
using OpenAI.Chat;

namespace MeuFitCoach.Infrastructure.Integrations
{
    public  class OpenAiPlanoDeTreinoGenerator : IGeradorDePlanoInteligente
    {
       private readonly OpenAIClient _openAiClient;
        public OpenAiPlanoDeTreinoGenerator(OpenAIClient openAiClient)
        {
            _openAiClient = openAiClient;
        }



        public async Task<string> GerarPlanoAsync (Usuario usuario)
        {
            string prompt = "Crie um plano de treino para {usuario.Nome} Com o objetivo {usuario.ObjetivoDoTreino}...";


            var response = await _OpenAiClient.GetChatCompletionAsync("gpt-4", new ChatCompletionOptions
            {


                string TextoDaResposta = response.Value.Choices[0].Message.Content;
                return TextoDaResposta;



        }

        }



    }
}
  