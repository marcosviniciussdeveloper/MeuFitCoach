

using MeuFitCoach.Application.Interface.Persistence;

using MeuFitCoach.Domain.Treino;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class PlanoRepository : IPlanoDeTreinoRepository
{

    private readonly AppDbContext _context;


    public PlanoRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<PlanoDeTreino> AddPlanoDeTreinoAsync(PlanoDeTreino planoDeTreino)
    {
         _context .PlanoDeTreino.Add(planoDeTreino);
            await _context.SaveChangesAsync();
            return planoDeTreino;
    }

    public async Task<bool> AtualizarPlanoDeTreinoAsync(PlanoDeTreino atualizarplano)
    {
       _context .PlanoDeTreino.Update(atualizarplano);
           var planoatualizado = await _context.SaveChangesAsync();
            return planoatualizado > 0;
    }

    public async Task<PlanoDeTreino> BuscarPlanoAtivoPorUsuarioIdAsync(Guid planoDeTreinoId)
    {
      return await _context.PlanoDeTreino
                .FirstOrDefaultAsync(p => p.Id == planoDeTreinoId && p.PlanoAtivo)
                ?? throw new KeyNotFoundException($"Active PlanoDeTreino with Id {planoDeTreinoId} not found.");
    }

    public async Task<PlanoDeTreino> BuscarPorIdAsync(Guid planoDeTreinoId)
    {
         return await _context.PlanoDeTreino.FirstOrDefaultAsync(p => p.Id == planoDeTreinoId)
                ?? throw new KeyNotFoundException($"PlanoDeTreino with Id {planoDeTreinoId} not found.");
    }

    public Task<bool> DeletePlanoDeTreinoAsync(Guid planoDeTreinoId)
    {
        _context.PlanoDeTreino.Remove(new PlanoDeTreino { Id = planoDeTreinoId });
        var resultado = _context.SaveChangesAsync();
        return Task.FromResult(resultado.Result > 0);
    }
}