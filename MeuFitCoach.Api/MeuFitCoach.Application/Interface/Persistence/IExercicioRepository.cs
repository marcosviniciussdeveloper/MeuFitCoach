using System;
using MeuFitCoach.Domain.Treino;

public interface  IExercicioRepository
{
	Task <Exercicio> AddExercicioAsync(Exercicio NovoExercicio);
	Task <Exercicio> ListExercicio();
	Task<Exercicio> GetByIdExercicioAysnc(Guid ExercicioId);
	Task<Exercicio> UpdateExercicioAsync(Exercicio ExercicioAtualizado);
	Task<Exercicio> DeleteExercicioAsync(Guid ExercicioId);


}
