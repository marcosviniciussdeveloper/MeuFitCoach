using MediatR;
using MeuFitCoach.Application.Interface.Persistence;
using MeuFitCoach.Application.Services.PlanoDeTreino;
using MeuFitCoach.Domain.Enum;
using MeuFitCoach.Domain.Usuarios;

/// Classe Especialista responsável por gerenciar todo o fluxo de conversa relacionado à criação de um plano de treino.
namespace MeuFitCoach.Application.Webhook;

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

        // Este switch controla apenas as etapas DEPOIS que o usuário já escolheu "Treino".
        switch (sessao.EstadoAtual)
        {
            case EstadoConversa.AguardandoOpcaoInicial:
                resposta = "Combinado, vamos criar seu plano de treino! Para começar, qual é o seu principal objetivo? (Ex: Ganhar massa muscular, Perder peso, etc.)";
                sessao.AtualizarEstado(EstadoConversa.AguardandoObjetivo);
                break;

            case EstadoConversa.AguardandoObjetivo:
                sessao.RegistrarObjetivo(mensagemRecebida);
                resposta = $"Entendido: seu objetivo é '{mensagemRecebida}'.\n\nQual seu nível de experiência?\n*1 - Iniciante*\n*2 - Intermediário*\n*3 - Avançado*";
                sessao.AtualizarEstado(EstadoConversa.AguardandoNivel); 
                break;

            case EstadoConversa.AguardandoNivel:
                sessao.RegistrarNivel(mensagemRecebida);
                resposta = "Perfeito. Para finalizar, você treina em academia com acesso a todos os equipamentos ou precisa de um treino para fazer em casa (com peso do corpo/halteres)?";
                sessao.AtualizarEstado(EstadoConversa.AguardandoEquipamentos);
                break;

            case EstadoConversa.AguardandoEquipamentos:
                sessao.RegistrarEquipamentos(mensagemRecebida);
                resposta = "Excelente! Recebi todas as suas informações. 💪\n\nEstou consultando a inteligência artificial para montar o melhor plano para você. Isso pode levar um minutinho...";

                _ = Task.Run(async () => {
                    usuario.Objetivo = sessao.Objetivo;
                    usuario.TempoDeTreino = sessao.Nivel;
                    await _usuarioRepository.AtualizarUsuarioAsync(usuario);

                    var command = new GerarPlanoDeTreinoCommand { UsuarioId = usuario.Id };
                    var planoGerado = await _mediator.Send(command);
                    await _sessaoRepository.UpdateAsync(sessao);
                });
                break;

            default:
                resposta = "Ops, parece que nos perdemos no meio da conversa sobre o treino. Vamos tentar de novo.";
                sessao.Limpar();
                break;
        }

        await _sessaoRepository.UpdateAsync(sessao);
        return resposta;
    }
}
