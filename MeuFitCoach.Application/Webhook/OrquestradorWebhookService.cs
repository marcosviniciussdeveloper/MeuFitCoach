using MediatR;
using MeuFitCoach.Application.Interface.Persistence;
using MeuFitCoach.Domain.Enum;
using MeuFitCoach.Domain.Usuarios;

//Classe responsável por orquestrar o fluxo de mensagens do webhook-

namespace MeuFitCoach.Application.Webhook
{
    public class OrquestradorWebhookService : IOrquestradorWebhookService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessaoRepository _sessaoRepository;
        private readonly TreinoFlowManager _treinoFlowManager;

        public OrquestradorWebhookService(
            IUsuarioRepository usuarioRepository,
            ISessaoRepository sessaoRepository,
            TreinoFlowManager treinoFlowManager)
        {
            _usuarioRepository = usuarioRepository;
            _sessaoRepository = sessaoRepository;
            _treinoFlowManager = treinoFlowManager;
        }

        // Método principal para processar mensagens recebidas
        public async Task<string> ProcessarMensagemAsync(string numerodeTelefone, string mensagemRecebida)
        {
            var usuario = await _usuarioRepository.ObterPorNumeroComSessaoAsync(numerodeTelefone);
            if (usuario == null)
            {
                usuario = new Usuario(numerodeTelefone, "Novo Usuário");
                var novaSessao = new SessaoConversa(usuario.Id);
                await _usuarioRepository.AddUsuarioAsync(usuario);
                usuario.Sessao = novaSessao; 
            }

            var sessao = usuario.Sessao;
            string resposta;

            if (sessao.PlanoEscolhido == TipoPlano.Nenhum)
            {
                switch (sessao.EstadoAtual)
                {
                    case EstadoConversa.Nulo:
                        resposta = "Olá! Eu sou seu FitCoach Pessoal. Para começarmos, o que você deseja hoje?\n\n*1 - Plano de Treino* 💪\n*2 - Plano de Dieta* 🍎";
                        sessao.AtualizarEstado(EstadoConversa.AguardandoOpcaoInicial);
                        break;
                    
                    case EstadoConversa.AguardandoOpcaoInicial:
                        if (mensagemRecebida.Contains("1") || mensagemRecebida.ToLower().Contains("treino"))
                        {
                            sessao.DefinirPlanoEscolhido(TipoPlano.Treino);
                            resposta = await _treinoFlowManager.Processar(usuario, mensagemRecebida);
                        }
                        else if (mensagemRecebida.Contains("2") || mensagemRecebida.ToLower().Contains("dieta"))
                        {
                            resposta = "O módulo de dieta está quase pronto! Por enquanto, vamos focar no seu treino? Se sim, digite '1'.";
                        }
                        else
                        {
                            resposta = "Opção inválida. Por favor, responda com o número *1* para Treino ou *2* para Dieta.";
                        }
                        break;
                    
                    default:
                        resposta = "Ops, me perdi. Vamos recomeçar. Você gostaria de um plano de (1) Treino ou (2) Dieta?";
                        sessao.Limpar();
                        break;
                }
                await _sessaoRepository.UpdateAsync(sessao);
            }
            else
            {
                switch (sessao.PlanoEscolhido)
                {
                    case TipoPlano.Treino:
                        resposta = await _treinoFlowManager.Processar(usuario, mensagemRecebida);
                        break;
                    // case TipoPlano.Dieta:
                    //     resposta = await _dietaFlowManager.Processar(usuario, mensagemRecebida);
                    //     break;
                    default:
                        resposta = "Não sei qual fluxo seguir. Vamos reiniciar...";
                        sessao.Limpar();
                        await _sessaoRepository.UpdateAsync(sessao);
                        break;
                }
            }

            return resposta;
        }
    }
}
