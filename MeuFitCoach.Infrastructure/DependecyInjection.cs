using MeuFitCoach.Application.Interface.Infrastructure;
using MeuFitCoach.Application.Interface.Persistence;
using MeuFitCoach.Infrastructure.Integrations;
using MeuFitCoach.Infrastructure.Persistence.NovaPasta;
using MeuFitCoach.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI;

//Classe responsável por registrar os serviços da camada de infraestrutura

namespace MeuFitCoach.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddScoped<IUsuarioRepository, UsuarioRepository>();
           services.AddScoped<IExercicioRepository, ExercicioRepository>();
           services.AddScoped<ISessaoRepository, SessaoRepository>();
           services.AddScoped<IPlanoDeTreinoRepository, PlanoRepository>();
            services.AddScoped<IGeradorDePlanoInteligente, OpenAiPlanoDeTreinoGenerator>();


            var apikey = configuration["OpenAiSettings:ApiKey"];
            if (!string.IsNullOrEmpty(apikey))
            {
                var openAiClient = new OpenAI.OpenAIClient(apikey);
                services.AddSingleton(openAiClient);
            }
            else
            {
                throw new InvalidOperationException("OpenAI API key is not configured.");
            }


            services.AddSingleton(new OpenAIClient(apikey));


            return services;
        }
    }
}
