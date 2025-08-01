using System;

public interface  IExercicioRepository
{
	Task <Exercicio> AddExercicioAsync(Exercicio NovoExercicio);
	Task ListExercicio();
	Task <Exercicio>GetByIdExercicioAysnc (Guid ExercicioId)



}
