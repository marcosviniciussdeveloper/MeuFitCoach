
using MeuFitCoach.Domain.Usuarios;

namespace MeuFitCoach.Application.Interface.Infrastructure
{
    public interface IGeradorDePlanoInteligente
    {
        public Task<string> GerarPlanoAsync(Usuario usuario)
        {

            string PlanoFixo = @"
            **Treino ABC - Foco em Hipertrofia**
            
            **Segunda-feira (Peito , Triceps e ombro)**
             -Supino Reto Com Barra : 4 séries de 8-12 repetições
            -Supino Inclinado Com Halteres : 4 séries de 10-15 repetições
            -Crucifixo : 3 séries de 12-15 repetições
             
   
            -Terça-feira (Costas e Biceps)
            -Puxada Frontal : 4 séries de 8-12 repetições
            -Remada Curvada : 4 séries de 10-15 repetições
            -Rosca Direta : 3 séries de 12-15 repetições


             **Quarta-feira (Pernas e Abdomen)**
            -cadeira Extensora : 4 séries de 8-12 repetições
            -Agachamento Livre : 4 séries de 10-15 repetições
            -Leg Press : 3 séries de 12-15 repetições
              
              ";

            return Task.FromResult(PlanoFixo);

        }

    }

}

