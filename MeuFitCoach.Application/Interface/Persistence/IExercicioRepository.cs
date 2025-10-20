using MeuFitCoach.Domain;
using MeuFitCoach.Domain.Treino;


public interface  IExercicioRepository
{
	Task <Guid> AddExercicioAsync(Exercicio NovoExercicio);
	Task <List<Exercicio>> ListExercicioAsync();
	Task<Exercicio> GetByIdExercicioAsync(Guid ExercicioId);
	Task<Exercicio> UpdateExercicioAsync(Exercicio ExercicioAtualizado);
	Task<bool> DeleteExercicioAsync(Guid ExercicioId);


}
