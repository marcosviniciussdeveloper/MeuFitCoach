
using MeuFitCoach.Domain.Enum;
using MeuFitCoach.Domain.Enums;

namespace MeuFitCoach.Domain.Usuarios
{
    public class SessaoConversa
    {
        public Guid Id { get; set; }
        
        public EstadoConversa EstadoAtual { get; set; }

        public Guid UsuarioId { get; set; }

        public virtual Usuario Usuario { get; private set; }

        public string? Objetivo { get; set; }

        public string ? Nivel {get;set; }
        public TipoPlano? PlanoEscolhido {get;set; }

        public string? Equipamentos { get; private set; }

        public DateTime UltimaInteracao {get;private set; }

        public SessaoConversa()
        {
            // Construtor padrão necessário para o Entity Framework
        }


        public SessaoConversa (Guid usuarioid)
        {
          
            Id = Guid.NewGuid();
            UsuarioId = usuarioid;
            EstadoAtual = EstadoConversa.AguardandoOpcaoInicial;
            UltimaInteracao = DateTime.UtcNow;
        }

        public void AtualizarEstado(EstadoConversa novoEstado)
        {
            EstadoAtual = novoEstado;
            UltimaInteracao = DateTime.UtcNow;
        }

        public void RegistrarObjetivo(string objetivo)
        {
            Objetivo = objetivo;
            UltimaInteracao = DateTime.UtcNow;
        }

        public void RegistrarNivel(string nivel)
        {
            Nivel = nivel;
            UltimaInteracao = DateTime.UtcNow;
        }

        public void DefinirPlanoEscolhido(TipoPlano plano)
        {
            PlanoEscolhido = plano;
        }


        public void RegistrarEquipamentos(string equipamentos)
        {
            Equipamentos = equipamentos;
            UltimaInteracao = DateTime.UtcNow;
        }
        //Limpar Os dados da sessao
        public void Limpar()
        {
            Objetivo = null;
            Nivel = null;
            Equipamentos = null;
            EstadoAtual = EstadoConversa.AguardandoOpcaoInicial;
            AtualizarEstado(EstadoConversa.Nulo);
        }
    }

}
