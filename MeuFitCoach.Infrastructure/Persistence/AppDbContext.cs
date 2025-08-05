namespace Persistence
{
    using Microsoft.EntityFrameworkCore;
    using MeuFitCoach.Domain.Entities;
    using MeuFitCoach.Infrastructure.Persistence.Context;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<PlanoDeTreino> PlanoDeTreino { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ExerciciosDaSessao> ExercicioDaSessao { get; set; }
        public DbSet<SessaoDeTreino> SessaoDeTreino { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.entity<Usuario>(builder =>
            {
                builder.HasMany(usuario => usuario.PlanoDeTreino)
                .WithOne(plano => plano.Usuario)
                .HasForeignKey(plano => plano.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            });


            modelBuilder.entity<PlanosDeTreino>(builder =>
            {
                builder.HasMany(plano => plano.SessaoDeTreino)
                .WithOne(sessao => sessao.PlanoDeTreino)
                .HasForeignKey(st => st.PlanoDeTreinoId)
                .OnDelete(DeleteBehavior.Cascade);
            });



            modelBuilder.entity<SessoesDeTreino>(builder =>
            {
                builder.HasMany(s => s.ListaDeExercicio)
                .WithOne(eds => eds.SessaoDeTreino)
                .HasForeignKey(eds => eds.SessaoDeTreinoId)
                .OnDelete(DeleteBehavior.Cascade);1
            });


            modelBuilder.entity<Exercicio>(builder =>
            {
                builder.HasMany(e => e.ExercicioDaSessao)
                .WithOne(eds => eds.Exercicio)
                .HasForeignKey(eds => eds.ExercicioId)
                .OnDelete(DeleteBehavior.Restrict);
            });


        }


    }



}
