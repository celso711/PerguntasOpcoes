using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class RelacaoPerguntaRepository : IRelacaoPerguntaRepository
    {
        private readonly string _connectionString;

        public RelacaoPerguntaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<RelacaoPergunta>> GetAllAsync()
        {
            var relacoes = new List<RelacaoPergunta>();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM RelacaoPergunta", connection);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var relacao = new RelacaoPergunta
                        {
                            // Atribua os campos aqui com reader.Get...
                        };
                        relacoes.Add(relacao);
                    }
                }
            }

            return relacoes;
        }

        // Implemente outros métodos conforme necessário
    }
}
