using Microsoft.AspNetCore.Mvc;

namespace MeuFitCoach.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreinoControllers : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTreinos()
        {
            // Lógica para obter os treinos
            return Ok();
        }


    }
}

