using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class RelacaoOpcaoPerguntaService
    {
        private readonly IRelacaoOpcaoPerguntaRepository _relacaoOpcaoPerguntaRepository;

        public RelacaoOpcaoPerguntaService(IRelacaoOpcaoPerguntaRepository relacaoOpcaoPerguntaRepository)
        {
            _relacaoOpcaoPerguntaRepository = relacaoOpcaoPerguntaRepository;
        }

        public async Task<IEnumerable<RelacaoOpcaoPergunta>> GetAllRelacaoOpcaoPerguntaAsync()
        {
            return await _relacaoOpcaoPerguntaRepository.GetAllAsync();
        }

        // Aqui, você pode adicionar outros métodos de serviço conforme necessário,
        // como métodos para buscar por ID, adicionar, atualizar ou deletar relações.
    }
}
