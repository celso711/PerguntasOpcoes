using System.Collections.Generic;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;

namespace PerguntasOpcoes.Repositories
{
    public interface IOpcaoRepository
    {
        Task<IEnumerable<Opcao>> GetAllAsync();
    }
}
