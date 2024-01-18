using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

public class PerguntaOpcaoController : ControllerBase
{
    private readonly PerguntaOpcaoService _perguntaOpcaoService;

    public PerguntaOpcaoController(PerguntaOpcaoService perguntaOpcaoService)
    {
        _perguntaOpcaoService = perguntaOpcaoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPerguntaOpcao()
    {
        var perguntasOpcoes = await _perguntaOpcaoService.GetAllPerguntaOpcaoAsync();
        return Ok(perguntasOpcoes);
    }
}
