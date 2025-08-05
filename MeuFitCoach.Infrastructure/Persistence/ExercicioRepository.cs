using Microsoft.EntityFrameworkCore;
using Persistence;
using MeuFitCoach.Repositories;


namespace MeuFitCoach.Repositories
{
 public class ExercicioRepository : IExercicioRepository;
{
private readonly AppDbContext _context;

public ExercicioRepository(AppDbContext context)
{
    _context = context;

}
public async Task AddAsync(Exercicio exercicio)
{
    await _context.Exercicios.AddAsync(exercicio);
    await _context.SaveChangesAsync();
}

public async Task<Exercicio> GetByIdAsync(Guid exercicioId)
{
    return await _context.Exercicios.FindAsync(exercicioId);
}

public async Task<IEnumerable<Exercicio>> ListAsync()
{
    return await _context.Exercicios.ToListAsync();
}


public async Task UpdateAsync(Exercicio exercicio)
{
    _context.Exercicios.Update(exercicio);
    await _context.SaveChangesAsync();
}

public async Task DeleteAsync(Guid exercicioId)
{
    var exercicio = await GetByIdAsync(exercicioId);
    if (exercicio != null)
    {
        _context.Exercicios.Remove(exercicio);
        await _context.SaveChangesAsync();
    }
}

}

