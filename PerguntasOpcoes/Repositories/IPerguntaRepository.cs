using System.Collections.Generic;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;

namespace PerguntasOpcoes.Repositories
{
    public interface IPerguntaRepository
    {
        Task<IEnumerable<Pergunta>> GetAllAsync();
        Task<Pergunta> GetPerguntaByIdAsync(int perguntaId);
    }

}
