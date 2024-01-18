using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
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
