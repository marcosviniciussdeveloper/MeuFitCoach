using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuFitCoach.Application.Interface.Persistence;
using MeuFitCoach.Domain.Treino;
using MeuFitCoach.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace MeuFitCoach.Infrastructure.Persistence.Repository
{
    public class SessaoRepository : ISessaoRepository
    {
        private readonly AppDbContext _context;

        public SessaoRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<SessaoConversa> GetById(Guid SessaoId)
        {
              return await _context.SessoesConversa.FirstOrDefaultAsync(s => s.Id == SessaoId)
                   ?? throw new KeyNotFoundException($"Sessao with Id {SessaoId} not found.");
        }

        public async Task UpdateAsync(SessaoConversa sessao)
        {
            _context.Entry(sessao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
