
public class ExercicioDaSessao
{
    public Guid Id { get; set; }
    public Guid SessaoDeTreinoId { get; set; }
    public Guid ExercicioId { get; set; }
    public int Series { get; set; }
    public string Repeticao { get; set; }
    public int OrdemDaSessao { get; set; }



    public ExercicioDaSessao(int series, string repeticao, int ordemdasessao)
    {
        if (ordemdasessao <= 0)
        {
            throw new ArgumentException("Ordem da sessao Invalida ");
        }

        if (series <= 0)
        {
            throw new ArgumentException("O numero de series está invalido");
         }
        if (repeticao == null)
        {

            throw new ArgumentException("O numero de repetição está invalido");

        }

        Id = Guid.NewGuid();
        Series = series;
        Repeticao = repeticao;
        OrdemDaSessao = ordemdasessao;



    }
}


