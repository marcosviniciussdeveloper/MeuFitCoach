using System.Runtime.CompilerServices;

namespace MeuFitCoach.Domain.Usuario
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public double Altura { get; set; }

        public double Peso { get; set; }

        public string NumeroWhatsapp { get; set; }

        public string Objetivo { get; set; }
        





        public Usuario( string nome, double altura, double peso, string objetivo, DateTime datadenascimento)
        {
            if (nome == null)
            {
                throw new ArgumentException("O nome não pode está em branco");

            }
            if (peso <= 0)
            {

                throw new ArgumentException("Por favor forneça um peso valido");
            }
            if (altura <= 0)
            {

                throw new ArgumentException("Por favor forneça uma altura valida");

            }
            if (Objetivo == null)
            {
                throw new ArgumentException("Por favor forneça o seu objetivo");
            }

            Id = Guid.NewGuid();
            Nome = nome;
            Altura = altura;
            Peso = peso;
            Objetivo = objetivo;
            DataDeNascimento = datadenascimento;


        }
    }
}