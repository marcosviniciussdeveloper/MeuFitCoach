using System.ComponentModel.DataAnnotations;
using System.Linq;
using MeuFitCoach.Application.Interface.Infrastructure;
using MeuFitCoach.Domain.Usuarios;
using OpenAI;
using OpenAI.Chat;



namespace MeuFitCoach.Infrastructure.Integrations;

public class OpenAiPlanoDeTreinoGenerator : IGeradorDePlanoInteligente
{
    private readonly OpenAIClient _openAiClient;

    
    public OpenAiPlanoDeTreinoGenerator(OpenAIClient openAiClient)
    {
        _openAiClient = openAiClient ?? throw new ArgumentNullException(nameof(openAiClient));
    }



    public async Task<string> GerarPlanoAsync(Usuario u, CancellationToken ct = default)
    {
        var systemPrompt =
        @"Você é um personal trainer profissional.
        Responda APENAS em JSON válido (sem texto fora do JSON).
        Schema:
        {
             ""diasPorSemana"": number,
            ""treinos"": [{ ""dia"": ""Segunda-feira"", ""exercicios"": [{ ""nome"": ""..."", ""series"": 4, ""repeticoes"": ""8-12"", ""descansoSegundos"": 90, ""observacoes"": ""..."" }]}]
        }";

        var idade = (int)((DateTime.UtcNow - u.DataDeNascimento).TotalDays / 365.25);
        var userPrompt =
        $@"Nome: {u.Nome}
        Idade: {idade}
        Altura: {u.Altura} cm
        Peso: {u.Peso} kg
        Objetivo: {u.Objetivo}
        Gere um plano semanal coerente com o objetivo, com exercícios comuns de academia.";



        var messages = new List<ChatMessage>
        {
            new SystemChatMessage( systemPrompt),
            new UserChatMessage( userPrompt)
        };


        var requestyBody = new
        {
            model = "gpt-4",
            messages = new[]
            {
                new { role = systemPrompt },
                new { role = userPrompt },


            },
            max_tokens = 200
        };




        return systemPrompt;


    }

}
