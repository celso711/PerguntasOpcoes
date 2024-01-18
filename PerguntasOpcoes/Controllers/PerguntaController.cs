using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
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
