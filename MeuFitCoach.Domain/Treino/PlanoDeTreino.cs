
using MeuFitCoach.Domain.Usuarios;

namespace MeuFitCoach.Domain.Treino
{
    public class PlanoDeTreino
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string NomeTreino { get; set; }
        public string Descricao { get; set; }
        public string ObjetivoDoTreino { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeTermino { get; set; }
        public bool PlanoAtivo { get; set; }
        public int FrequenciaSemanal { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<SessaoDeTreino> SessoesDeTreino { get; set; }

        public PlanoDeTreino()
        {       
        }

        public PlanoDeTreino(Guid usuarioid, string nometreino, string descricao, string objetivodotreino, DateTime datadeinicio, DateTime datadetermino, bool planoativo)
        {
            if (nometreino == null)
            {
                throw new ArgumentException("O nome do treino não pode está em vazio");

            }
            if (objetivodotreino == null)
            {
                throw new ArgumentException("O objetivo do treino está invalidao , tente novamente");
            }

            Id = Guid.NewGuid();
            UsuarioId = usuarioid;
            NomeTreino = nometreino;
            Descricao = descricao;
            ObjetivoDoTreino = objetivodotreino;
            DataDeInicio = datadeinicio;
            DataDeTermino = datadetermino;
            PlanoAtivo = planoativo;

        }
    }
}
