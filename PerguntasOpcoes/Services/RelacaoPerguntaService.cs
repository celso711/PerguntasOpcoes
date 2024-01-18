using System.Collections.Generic;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;
using PerguntasOpcoes.Repositories;

namespace PerguntasOpcoes.Services
{
    public class RelacaoPerguntaService
    {
        private readonly IRelacaoPerguntaRepository _relacaoPerguntaRepository;

        public RelacaoPerguntaService(IRelacaoPerguntaRepository relacaoPerguntaRepository)
        {
            _relacaoPerguntaRepository = relacaoPerguntaRepository;
        }

        public async Task<IEnumerable<RelacaoPergunta>> GetAllRelacaoPerguntaAsync()
        {
            return await _relacaoPerguntaRepository.GetAllAsync();
        }

        // Aqui você pode adicionar outros métodos conforme necessário, como métodos para
        // buscar por ID, adicionar, atualizar ou deletar relações.
    }
}
