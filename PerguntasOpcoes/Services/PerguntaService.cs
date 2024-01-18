using System.Collections.Generic;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;
using PerguntasOpcoes.Repositories;

namespace PerguntasOpcoes.Services
{
    public class PerguntaService
    {
        private readonly IPerguntaRepository _perguntaRepository;

        public PerguntaService(IPerguntaRepository perguntaRepository)
        {
            _perguntaRepository = perguntaRepository;
        }

        public async Task<IEnumerable<Pergunta>> GetAllPerguntasAsync()
        {
            return await _perguntaRepository.GetAllAsync();
        }
    }
}
