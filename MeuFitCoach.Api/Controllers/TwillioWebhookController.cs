using Microsoft.AspNetCore.Mvc;
using MeuFitCoach.Application.Webhook;
using Twilio.TwiML;
using Twilio.TwiML.Messaging;

namespace MeuFitCoach.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwilioWebhookController : ControllerBase
    {
        private readonly IOrquestradorWebhookService _orquestradorWebhookService;

        public TwilioWebhookController(IOrquestradorWebhookService orquestradorWebhookService)
        {
            _orquestradorWebhookService = orquestradorWebhookService;
        }

        /// <summary>
        /// Endpoint chamado automaticamente pelo Twilio quando o usuário envia mensagem no WhatsApp.
        /// </summary>
        [HttpPost("receive")]
        public async Task<IActionResult> Receive([FromForm] string From, [FromForm] string Body)
        {
            if (string.IsNullOrWhiteSpace(From) || string.IsNullOrWhiteSpace(Body))
                return BadRequest("Mensagem inválida.");

            var numero = From.Replace("whatsapp:", "").Trim();
            var mensagem = Body.Trim();

   
            var resposta = await _orquestradorWebhookService.ProcessarMensagemAsync(numero, mensagem);

            var messagingResponse = new MessagingResponse();
            messagingResponse.Message(resposta);

            return Content(messagingResponse.ToString(), "application/xml");
        }

        [HttpGet("ping")]
        public IActionResult Ping() => Ok("Twilio Webhook ativo ✅");
    }
}
