using PerguntasOpcoes.Models;
using PerguntasOpcoes.Repositories;

public class OpcaoService
{
    private readonly IOpcaoRepository _opcaoRepository;

    public OpcaoService(IOpcaoRepository opcaoRepository)
    {
        _opcaoRepository = opcaoRepository;
    }

    public async Task<IEnumerable<Opcao>> GetAllOpcoesAsync()
    {
        return await _opcaoRepository.GetAllAsync();
    }
}
