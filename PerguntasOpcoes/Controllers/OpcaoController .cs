using Microsoft.AspNetCore.Mvc;

public class OpcaoController : ControllerBase
{
    private readonly OpcaoService _opcaoService;

    public OpcaoController(OpcaoService opcaoService)
    {
        _opcaoService = opcaoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOpcoes()
    {
        var opcoes = await _opcaoService.GetAllOpcoesAsync();
        return Ok(opcoes);
    }
}
