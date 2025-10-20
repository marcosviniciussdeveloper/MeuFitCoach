using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Twilio.Http;

namespace MeuFitCoach.Application.Services.PlanoDeTreino
{
    public class GerarPlanoDeTreinoCommand : IRequest<string>
    { 
        public Guid UsuarioId { get; set; } 
    }
}
