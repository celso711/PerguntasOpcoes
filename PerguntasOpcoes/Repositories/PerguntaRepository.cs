using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
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
                        perguntas.Add(new Pergunta
                        {
                            // Atribua os campos aqui
                        });
                    }
                }
            }

            return perguntas;
        }
    }
}
