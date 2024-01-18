using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;

namespace PerguntasOpcoes.Repositories
{
    public class PerguntaRepository : IPerguntaRepository
    {
        private readonly string _connectionString;

        public PerguntaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Pergunta>> GetAllAsync()
        {
            var perguntas = new List<Pergunta>();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Pergunta", connection);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var pergunta = new Pergunta
                        {
                            PerguntaID = reader.GetInt32(reader.GetOrdinal("PerguntaID")),
                            CategoriaID = reader.GetInt32(reader.GetOrdinal("CategoriaID")),
                            Texto = reader.GetString(reader.GetOrdinal("Texto")),
                            TipoPergunta = reader.GetInt32(reader.GetOrdinal("TipoPergunta")),
                            OrdemExibicao = reader.GetInt32(reader.GetOrdinal("OrdemExibicao")),
                            Ativa = reader.GetBoolean(reader.GetOrdinal("Ativa"))
                        };
                        perguntas.Add(pergunta);
                    }
                }
            }

            return perguntas;
        }
    }
}
