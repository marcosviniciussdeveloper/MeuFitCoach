using MediatR;
using MeuFitCoach.Application.Interface.Persistence;
using MeuFitCoach.Application.Services.PlanoDeTreino;
using MeuFitCoach.Domain.Enum;
using MeuFitCoach.Domain.Usuarios;

namespace MeuFitCoach.Application.Webhook
{
    public class TreinoFlowManager : IFlowManager
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessaoRepository _sessaoRepository;
        private readonly IMediator _mediator;

        public TreinoFlowManager(
            IUsuarioRepository usuarioRepository,
            ISessaoRepository sessaoRepository,
            IMediator mediator)
        {
            _usuarioRepository = usuarioRepository;
            _sessaoRepository = sessaoRepository;
            _mediator = mediator;
        }

        public async Task<string> Processar(Usuario usuario, string mensagemRecebida)
        {
            var sessao = usuario.Sessao;
            string resposta;

           //Caso o usuario envie outra mensagem apos , ele enviar a requição de treino 
            if (sessao.EstadoAtual == EstadoConversa.ProcessandoPlano)
            {
                return "⏳ Ainda estou montando seu plano personalizado, aguarde só mais um instante... 💪";
            }

            //logica após gerar um plano 
            if (sessao.EstadoAtual == EstadoConversa.Finalizado)
            {
                sessao.Limpar();
                sessao.AtualizarEstado(EstadoConversa.AguardandoOpcaoInicial);
                await _sessaoRepository.UpdateAsync(sessao);
                return "Seu plano foi finalizado! 🎯 Deseja gerar um novo?\n\n*1 - Sim, quero outro plano*\n*2 - Não, obrigado*";
            }

       
            switch (sessao.EstadoAtual)
            {
                case EstadoConversa.AguardandoOpcaoInicial:
                    resposta = "Combinado, vamos criar seu plano de treino! 💪\nPara começar, qual é o seu principal objetivo? (Ex: Ganhar massa muscular, Perder peso, etc.)";
                    sessao.AtualizarEstado(EstadoConversa.AguardandoObjetivo);
                    break;

                case EstadoConversa.AguardandoObjetivo:
                    sessao.RegistrarObjetivo(mensagemRecebida);
                    resposta = $"Entendido: seu objetivo é *{mensagemRecebida}*.\n\nQual seu nível de experiência?\n*1 - Iniciante*\n*2 - Intermediário*\n*3 - Avançado*";
                    sessao.AtualizarEstado(EstadoConversa.AguardandoNivel);
                    break;

                case EstadoConversa.AguardandoNivel:
                    var nivel = mensagemRecebida.Trim().ToLower();

                    if (nivel.Contains("1") || nivel.Contains("iniciante"))
                        sessao.RegistrarNivel("Iniciante");
                    else if (nivel.Contains("2") || nivel.Contains("intermediario"))
                        sessao.RegistrarNivel("Intermediário");
                    else if (nivel.Contains("3") || nivel.Contains("avançado"))
                        sessao.RegistrarNivel("Avançado");
                    else
                    {
                        resposta = "Não entendi seu nível 😅. Escolha:\n*1 - Iniciante*\n*2 - Intermediário*\n*3 - Avançado*";
                        await _sessaoRepository.UpdateAsync(sessao);
                        return resposta;
                    }

                    resposta = "Perfeito! Agora me diga: você treina em *academia* 🏋️‍♂️ ou *casa* 🏠?";
                    sessao.AtualizarEstado(EstadoConversa.AguardandoEquipamentos);
                    break;

                case EstadoConversa.AguardandoEquipamentos:
                    sessao.RegistrarEquipamentos(mensagemRecebida);
                    resposta = "Excelente! Recebi todas as suas informações. 💪\n\nEstou montando seu plano personalizado. Isso pode levar alguns segundos...";

            
                    sessao.AtualizarEstado(EstadoConversa.ProcessandoPlano);
                    await _sessaoRepository.UpdateAsync(sessao);

                   
                    _ = Task.Run(async () =>
                    {//Aqui atualizamos o estado da conversa caso algum erro ocorra retornamos uma exception
                        try
                        {
                            usuario.Objetivo = sessao.Objetivo;
                            usuario.TempoDeTreino = sessao.Nivel;

                            await _usuarioRepository.AtualizarUsuarioAsync(usuario);

                            var command = new GerarPlanoDeTreinoCommand { UsuarioId = usuario.Id };
                            var planoGerado = await _mediator.Send(command);

                     
                            sessao.AtualizarEstado(EstadoConversa.Finalizado);
                            await _sessaoRepository.UpdateAsync(sessao);

                           
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"❌ Erro ao gerar plano: {ex.Message}");
                            sessao.Limpar();
                            sessao.AtualizarEstado(EstadoConversa.AguardandoOpcaoInicial);
                            await _sessaoRepository.UpdateAsync(sessao);
                        }
                    });
                    break;

                default:
                    resposta = "Ops 😅, parece que nos perdemos na conversa. Vamos recomeçar?\n\n*1 - Plano de Treino*\n*2 - Plano de Dieta*";
                    sessao.Limpar();
                    sessao.AtualizarEstado(EstadoConversa.AguardandoOpcaoInicial);
                    break;
            }

            await _sessaoRepository.UpdateAsync(sessao);
            return resposta;
        }
    }
}
