using System.Collections.Generic;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;

namespace PerguntasOpcoes.Repositories
{
    public interface IRelacaoOpcaoPerguntaRepository
    {
        Task<IEnumerable<RelacaoOpcaoPergunta>> GetAllAsync();
    }
}
