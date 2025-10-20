using MeuFitCoach.Application.Webhook;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


// classe responsável por registrar os serviços da camada de aplicação

namespace MeuFitCoach.Application
{
    public static class DependencyInjection
    {

      public static IServiceCollection AddApplicationServices(this IServiceCollection services)
      {
          services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
          
            services.AddScoped<TreinoFlowManager>();

            services.AddScoped<IOrquestradorWebhookService, OrquestradorWebhookService>();

            return services;
        }
    }
}
