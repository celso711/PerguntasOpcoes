using System.Collections.Generic;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;

namespace PerguntasOpcoes.Repositories
{
    public interface IRelacaoPerguntaRepository
    {
        Task<IEnumerable<RelacaoPergunta>> GetAllAsync();
    }
}
