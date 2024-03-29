﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PerguntasOpcoes.Models;

namespace PerguntasOpcoes.Repositories
{
    public class PerguntaOpcaoRepository : IPerguntaOpcaoRepository
    {
        private readonly string _connectionString;

        public PerguntaOpcaoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<PerguntaOpcao>> GetAllAsync()
        {
            var perguntasOpcoes = new List<PerguntaOpcao>();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM PerguntaOpcao", connection);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var perguntaOpcao = new PerguntaOpcao
                        {
                            PerguntaOpcaoID = reader.GetInt32(reader.GetOrdinal("PerguntaOpcaoID")),
                            PerguntaID = reader.GetInt32(reader.GetOrdinal("PerguntaID")),
                            OpcaoID = reader.GetInt32(reader.GetOrdinal("OpcaoID"))
                            // Atribua outras propriedades aqui
                        };
                        perguntasOpcoes.Add(perguntaOpcao);
                    }
                }
            }

            return perguntasOpcoes;
        }
    }
}
