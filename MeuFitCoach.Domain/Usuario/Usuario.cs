using System;
using System.Collections.Generic;
using MeuFitCoach.Domain.Treino;

namespace MeuFitCoach.Domain.Usuarios
{//Classe Usuario representa um usuario do sistema
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string TempoDeTreino { get; set; }
        public string NumeroTelefone { get; set; }
        public string Objetivo { get; set; }

        public virtual SessaoConversa Sessao { get; set; }
        public virtual ICollection<PlanoDeTreino> PlanosDeTreino { get; set; }

        public Usuario()
        { // Construtor padrão necessário para o Entity Framework
        }


        // Construtor para criar um usuario com numero de telefone e nome
        public Usuario(string numeroTelefone, string nome)
        {
            if (string.IsNullOrWhiteSpace(numeroTelefone))
            {
                throw new ArgumentException("O número de telefone é obrigatório.");
            }

            Id = Guid.NewGuid();
            NumeroTelefone = numeroTelefone;
            Nome = nome;
            UserName = numeroTelefone;
        }

        // Construtor para criar um usuario com todos os detalhes

        public Usuario(string username, string tempodetreino, string nome, double altura, double peso, string objetivo, DateTime datadenascimento)
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
            if (objetivo == null)
            {
                throw new ArgumentException("Por favor forneça o seu objetivo");
            }
            if (datadenascimento >= DateTime.Now)
            {
                throw new ArgumentException("A data de nascimento não pode ser no futuro");
            }
            if (username == null)
            {
                throw new ArgumentException("O nome de usuario não pode estar em branco");
            }

            Id = Guid.NewGuid();
            TempoDeTreino = tempodetreino;
            Nome = nome;
            UserName = username;
            Altura = altura;
            Peso = peso;
            Objetivo = objetivo;
            DataDeNascimento = datadenascimento;
        }
    }
}