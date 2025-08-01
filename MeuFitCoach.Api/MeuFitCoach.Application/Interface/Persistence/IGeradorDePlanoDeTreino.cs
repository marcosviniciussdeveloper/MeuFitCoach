public interface IGeradorDePlanoTreino
{
    Task<> GeneratePlanoTreino(Guid UsuarioId);
    void ListrPlanoTreino();



}