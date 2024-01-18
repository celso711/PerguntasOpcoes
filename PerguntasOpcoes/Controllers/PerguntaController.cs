using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PerguntasOpcoes.Services;

namespace PerguntasOpcoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerguntaController : ControllerBase
    {
        private readonly PerguntaService _perguntaService;

        public PerguntaController(PerguntaService perguntaService)
        {
            _perguntaService = perguntaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPerguntas()
        {
            var perguntas = await _perguntaService.GetAllPerguntasAsync();
            return Ok(perguntas);
        }
    }
}
