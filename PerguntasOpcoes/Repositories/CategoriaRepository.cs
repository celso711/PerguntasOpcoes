using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;

namespace PerguntasOpcoes.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _connectionString;

        public CategoriaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            var categorias = new List<Categoria>();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Categoria", connection);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        categorias.Add(new Categoria
                        {
                            CategoriaID = reader.GetInt32(reader.GetOrdinal("CategoriaID")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            Descricao = reader.GetString(reader.GetOrdinal("Descricao"))
                        });
                    }
                }
            }

            return categorias;
        }
    }
}
