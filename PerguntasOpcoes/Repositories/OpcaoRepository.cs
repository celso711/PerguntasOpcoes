using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;

namespace PerguntasOpcoes.Repositories
{
    public class OpcaoRepository : IOpcaoRepository
    {
        private readonly string _connectionString;

        public OpcaoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Opcao>> GetAllAsync()
        {
            var opcoes = new List<Opcao>();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Opcao", connection);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var opcao = new Opcao
                        {
                            OpcaoID = reader.GetInt32(reader.GetOrdinal("OpcaoID")),
                            Texto = reader.GetString(reader.GetOrdinal("Texto")),
                            OrdemExibicao = reader.GetInt32(reader.GetOrdinal("OrdemExibicao")),
                            Ativa = reader.GetBoolean(reader.GetOrdinal("Ativa"))
                        };
                        opcoes.Add(opcao);
                    }
                }
            }

            return opcoes;
        }
    }
}
