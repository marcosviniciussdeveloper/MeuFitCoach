

using MeuFitCoach.Application.Interface.Infrastructure;
using MeuFitCoach.Infrastructure.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace MeuFitCoach.Infrastructure.Integrations.Services
{

    public class WhatsappService : IWhatsAppService
    {


        private readonly TwilioSettings _twilioSettings;


        public WhatsappService(Microsoft.Extensions.Options.IOptions<TwilioSettings> twilioOptions)
        {

            _twilioSettings = twilioOptions.Value;
        }

        public async Task SendMessageAsync(string numeroWhatsapp, string mensagem, string NomeUsuario)
        {

            var numeroDoBot = _twilioSettings.WhatsappNumber;

            var MensagemDestinario = new PhoneNumber($"Whatsapp:{numeroWhatsapp}");
            var MensagemRementente = new PhoneNumber($"Whatapp:{numeroDoBot}");

            await MessageResource.CreateAsync(
                to: MensagemDestinario,
                from: MensagemRementente,
                body: mensagem

                );

        }  
                
                
    }
}
