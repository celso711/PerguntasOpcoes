using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PerguntasOpcoes.Services;

public class RelacaoOpcaoPerguntaController : ControllerBase
{
    private readonly RelacaoOpcaoPerguntaService _relacaoOpcaoPerguntaService;

    public RelacaoOpcaoPerguntaController(RelacaoOpcaoPerguntaService relacaoOpcaoPerguntaService)
    {
        _relacaoOpcaoPerguntaService = relacaoOpcaoPerguntaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRelacaoOpcaoPergunta()
    {
        var relacoesOpcaoPergunta = await _relacaoOpcaoPerguntaService.GetAllRelacaoOpcaoPerguntaAsync();
        return Ok(relacoesOpcaoPergunta);
    }
}
