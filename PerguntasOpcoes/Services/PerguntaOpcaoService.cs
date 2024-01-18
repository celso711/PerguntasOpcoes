using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class PerguntaOpcaoService
    {
        private readonly IPerguntaOpcaoRepository _perguntaOpcaoRepository;

        public PerguntaOpcaoService(IPerguntaOpcaoRepository perguntaOpcaoRepository)
        {
            _perguntaOpcaoRepository = perguntaOpcaoRepository;
        }

        public async Task<IEnumerable<PerguntaOpcao>> GetAllPerguntaOpcaoAsync()
        {
            return await _perguntaOpcaoRepository.GetAllAsync();
        }

        // Aqui você pode adicionar outros métodos conforme necessário
    }
}
