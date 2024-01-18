using System.Collections.Generic;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;

namespace PerguntasOpcoes.Repositories
{
    public interface IPerguntaOpcaoRepository
    {
        Task<IEnumerable<PerguntaOpcao>> GetAllAsync();
    }
}
