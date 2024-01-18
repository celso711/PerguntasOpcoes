using System.Collections.Generic;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;
using PerguntasOpcoes.Repositories;

namespace PerguntasOpcoes.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
        {
            return await _categoriaRepository.GetAllAsync();
        }
    }
}
