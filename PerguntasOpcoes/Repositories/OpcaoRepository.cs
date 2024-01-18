using System.Data.SqlClient;
using WebApplication1.Models;
using WebApplication1.Repositories;

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
                    opcoes.Add(new Opcao
                    {
                        // Atribua os campos aqui
                    });
                }
            }
        }

        return opcoes;
    }
}
