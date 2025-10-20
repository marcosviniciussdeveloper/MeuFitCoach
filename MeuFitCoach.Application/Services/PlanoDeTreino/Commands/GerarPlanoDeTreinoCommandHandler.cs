using MediatR;
using MeuFitCoach.Application.Interface.Infrastructure;
using MeuFitCoach.Application.Interface.Persistence;
using MeuFitCoach.Domain.Usuarios;
using PlanoDeTreinoEntity = MeuFitCoach.Domain.Treino.PlanoDeTreino;

namespace MeuFitCoach.Application.Services.PlanoDeTreino.Commands
{
    /// <summary>
    /// Implementa o manipulador de comando para gerar um plano de treino.
    /// </summary>
    public class GerarPlanoDeTreinoCommandHandler : IRequestHandler<GerarPlanoDeTreinoCommand, string>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPlanoDeTreinoRepository _planoDeTreinoRepository;
        private readonly IGeradorDePlanoInteligente _geradorDePlanoInteligente;

        public GerarPlanoDeTreinoCommandHandler(IUsuarioRepository usuarioRepository, IPlanoDeTreinoRepository planoDeTreinoRepository, IGeradorDePlanoInteligente geradorDePlanoInteligente)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _planoDeTreinoRepository = planoDeTreinoRepository ?? throw new ArgumentNullException(nameof(planoDeTreinoRepository));
            _geradorDePlanoInteligente = geradorDePlanoInteligente ?? throw new ArgumentNullException(nameof(geradorDePlanoInteligente));
        }

      
        public async Task<string> Handle(GerarPlanoDeTreinoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.UsuarioId);
            var planoGeradoEmTexto = await _geradorDePlanoInteligente.GerarPlanoAsync(usuario, cancellationToken);

            if (string.IsNullOrWhiteSpace(planoGeradoEmTexto))
            {
                return "Desculpe, tive um problema ao gerar seu plano. Tente novamente em alguns instantes.";
            }

            var novoPlano = new PlanoDeTreinoEntity(
                 usuario.Id,
                 $"Treino de {usuario.Objetivo}",
                 planoGeradoEmTexto,
                 usuario.Objetivo,
                 DateTime.UtcNow,
                 DateTime.UtcNow.AddDays(60),
                 true
            );

            await _planoDeTreinoRepository.AddPlanoDeTreinoAsync(novoPlano);
            return planoGeradoEmTexto;
        }

     
    }
}