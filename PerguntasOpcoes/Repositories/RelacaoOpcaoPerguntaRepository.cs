using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class RelacaoOpcaoPerguntaRepository : IRelacaoOpcaoPerguntaRepository
    {
        private readonly string _connectionString;

        public RelacaoOpcaoPerguntaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<RelacaoOpcaoPergunta>> GetAllAsync()
        {
            var relacoes = new List<RelacaoOpcaoPergunta>();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM RelacaoOpcaoPergunta", connection);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var relacao = new RelacaoOpcaoPergunta
                        {
                            RelacaoID = reader.GetInt32(reader.GetOrdinal("RelacaoID")),
                            OpcaoID = reader.GetInt32(reader.GetOrdinal("OpcaoID")),
                            PerguntaSubsequenteID = reader.GetInt32(reader.GetOrdinal("PerguntaSubsequenteID"))
                        };
                        relacoes.Add(relacao);
                    }
                }
            }

            return relacoes;
        }
    }
}
