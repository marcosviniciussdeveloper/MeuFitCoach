
using Microsoft.EntityFrameworkCore;
using MeuFitCoach.Domain.Treino;
using MeuFitCoach.Domain.Usuarios;


namespace Persistence
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<PlanoDeTreino> PlanoDeTreino { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ExercicioDaSessao> ExercicioDaSessao { get; set; }

        public DbSet<SessaoDeTreino> SessaoDeTreino { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(builder =>
            {
                builder.HasMany(usuario => usuario.PlanosDeTreino)
                       .WithOne(plano => plano.Usuario)
                       .HasForeignKey(plano => plano.UsuarioId)
                       .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<PlanoDeTreino>(builder =>
            {
                builder.HasMany(plano => plano.SessoesDeTreino)
                       .WithOne(sessao => sessao.PlanoDeTreino)
                       .HasForeignKey(st => st.PlanoDeTreinoId)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            

        modelBuilder.Entity<SessaoDeTreino>(builder =>
            {
                builder.HasMany(sessao => sessao.ListaDeExercicios)
                       .WithOne(exercicio => exercicio.SessaoDeTreino)
                       .HasForeignKey(eds => eds.SessaoDeTreinoId)
                       .OnDelete(DeleteBehavior.Cascade);
            });
   



            modelBuilder.Entity<Exercicio>(builder =>
            {
                builder.HasMany(exercicio => exercicio.ExercicioDaSessao)
                       .WithOne(eds => eds.Exercicio)
                       .HasForeignKey(eds => eds.ExercicioId)
                       .OnDelete(DeleteBehavior.Restrict);
            });


        }


    }



}
