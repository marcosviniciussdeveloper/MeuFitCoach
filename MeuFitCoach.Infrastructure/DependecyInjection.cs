using MeuFitCoach.Application.Interface.Infrastructure;
using MeuFitCoach.Application.Interface.Persistence;
using MeuFitCoach.Infrastructure.Configuration;
using MeuFitCoach.Infrastructure.Integrations;
using MeuFitCoach.Infrastructure.Integrations.Services;
using MeuFitCoach.Infrastructure.Persistence.NovaPasta;
using MeuFitCoach.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI;

namespace MeuFitCoach.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 🔹 Repositórios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IExercicioRepository, ExercicioRepository>();
            services.AddScoped<ISessaoRepository, SessaoRepository>();
            services.AddScoped<IPlanoDeTreinoRepository, PlanoRepository>();

            // 🔹 Serviço de geração de plano inteligente (OpenAI)
            services.AddScoped<IGeradorDePlanoInteligente, OpenAiPlanoDeTreinoGenerator>();

            // ===============================================
            // 🔹 Configuração do OpenAI
            // ===============================================
            var openAiApiKey = configuration["OpenAiSettings:ApiKey"];
            if (string.IsNullOrEmpty(openAiApiKey))
                throw new InvalidOperationException("OpenAI API key is not configured in appsettings.");

            services.AddSingleton(new OpenAIClient(openAiApiKey));

            // ===============================================
            // 🔹 Configuração do Twilio (WhatsApp)
            // ===============================================
            services.Configure<TwilioSettings>(configuration.GetSection("TwilioSettings"));
            services.AddScoped<IWhatsAppService, WhatsappService>();

            return services;
        }
    }
}
