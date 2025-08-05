using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuFitCoach.Domain;

namespace MeuFitCoach.Domain.SessaoDeTreino
{
    public class SessaoDeTreino
    {
        public Guid Id { get; set; }
        public Guid PlanoDeTreinoId { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public string NomeSessaoTreino { get; set; }



        public List<ExercicioDaSessao> ListaDeExercicios { get; private set; }





        public SessaoDeTreino(Guid planodetreinoid, string descricao, int ordem, string nomesessaotreino )
        {

            if (nomesessaotreino == null)
            {
                throw new ArgumentException("O nome está invalidao tente novamente  ");


            }

            if (descricao == null)
            {

                throw new ArgumentException("A descricao está invalida");
            }

            if (ordem <= 0)
            {
                throw new ArgumentException("A ordem está invalida");
            }

            if (planodetreinoid == Guid.Empty)
            {
                throw new ArgumentException("A sessão de treino deve estar associada a um plano de treino válido.");
            }

            Id = Guid.NewGuid();
            PlanoDeTreinoId = planodetreinoid;
            Descricao = descricao;
            Ordem = ordem;
            NomeSessaoTreino = nomesessaotreino;
            ListaDeExercicios = new List<ExercicioDaSessao>();
            



        }
    }
}
