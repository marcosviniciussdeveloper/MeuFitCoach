using Persistence;
using MeuFitCoach.Domain.Treino;
using Microsoft.EntityFrameworkCore;

namespace MeuFitCoach.Infrastructure.Persistence.NovaPasta
{
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly AppDbContext _context;
        public ExercicioRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Guid> AddExercicioAsync(Exercicio NovoExercicio)
        {
            _context.Exercicios.Add(NovoExercicio);
            await _context.SaveChangesAsync();
            return NovoExercicio.Id;

        }

        public async Task<bool> DeleteExercicioAsync(Guid ExercicioId)
        {
            _context.Exercicios.Remove(new Exercicio { Id = ExercicioId });
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<Exercicio> GetByIdExercicioAsync(Guid ExercicioId)
        {
           return await _context.Exercicios
                .FirstOrDefaultAsync(e => e.Id == ExercicioId) 
                ?? throw new KeyNotFoundException($"Exercicio with Id {ExercicioId} not found.");
        }

        public async Task<List<Exercicio>> ListExercicioAsync()
        {
          var TodosExericicos = await  _context.Exercicios.ToListAsync();
            return TodosExericicos;
        }

        public async Task<Exercicio> UpdateExercicioAsync(Exercicio ExercicioAtualizado)
        {
            _context.Exercicios.Update(ExercicioAtualizado);
            await _context.SaveChangesAsync();

            return ExercicioAtualizado;
        }
    }
}





