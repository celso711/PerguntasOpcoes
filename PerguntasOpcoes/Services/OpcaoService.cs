using WebApplication1.Models;
using WebApplication1.Repositories;

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
