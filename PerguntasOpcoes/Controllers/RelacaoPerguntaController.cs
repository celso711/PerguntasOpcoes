using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PerguntasOpcoes.Services;

public class RelacaoPerguntaController : ControllerBase
{
    private readonly RelacaoPerguntaService _relacaoPerguntaService;

    public RelacaoPerguntaController(RelacaoPerguntaService relacaoPerguntaService)
    {
        _relacaoPerguntaService = relacaoPerguntaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRelacaoPergunta()
    {
        var relacoesPergunta = await _relacaoPerguntaService.GetAllRelacaoPerguntaAsync();
        return Ok(relacoesPergunta);
    }
}
