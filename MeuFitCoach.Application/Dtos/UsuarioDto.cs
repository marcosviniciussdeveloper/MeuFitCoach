using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFitCoach.Application.Dtos
{
    public class CreateUsuarioDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string Nome { get; set; } = string .Empty;
        public string Email { get; set; } = string.Empty;
        public string NumeroWhatsapp { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string TempoDeTreino { get; set; } = string.Empty;


        public float PesoAtual { get; set; }
        public float Altura { get; set; }

    }

    public class CarregarUsuarioDto 
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Objetivo { get; set; }

        public string TempoDeTreino { get; set; }

        public string DataDeNascimento { get; set; }

        public float PesoAtual { get; set; }

        public float Altura { get; set; }
     
    }
}
