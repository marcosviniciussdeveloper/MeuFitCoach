using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Domain.Treino
{
    public  class Exercicio
    {
        public Guid Id { get; set; }
        public string NomeExercicio { get; set; }
        public string DescricaoExercicio { get; set; }
        public string IntrucoesExercicio { get; set; }
       public virtual ICollection<ExercicioDaSessao> ExercicioDaSessao { get; set; }

        public Exercicio()
        {
       
        }

        public Exercicio (Guid id, string nomeExercicio, string descricaoExercicio, string intrucoesExercicio)
        {
           
            if (string.IsNullOrWhiteSpace(nomeExercicio))
            {
                throw new ArgumentException("O nome do exercício não pode estar vazio.", nameof(nomeExercicio));
            }


            if (string.IsNullOrWhiteSpace(descricaoExercicio))
            {
                throw new ArgumentException("A descrição do exercício não pode estar vazia.", nameof(descricaoExercicio));
            }


            if (string.IsNullOrWhiteSpace(intrucoesExercicio))
            {
                throw new ArgumentException("As instruções do exercício não podem estar vazias.", nameof(intrucoesExercicio));
            }

            Id = Guid.NewGuid();
            NomeExercicio = nomeExercicio;
            DescricaoExercicio = descricaoExercicio;
            IntrucoesExercicio = intrucoesExercicio;
            ExercicioDaSessao = new List<ExercicioDaSessao>();
        }
    }
}
