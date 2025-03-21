using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Infra.Data.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly string _connectionString;

        public RelatorioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<DataTable> GetLivrosPorAutorAsync()
        {
            var dataTable = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var command = new SqlCommand("SELECT Autor, Titulo, Editora, Edicao, AnoPublicacao, Assunto FROM vw_RelatorioLivros ORDER BY Autor", conn))
                {
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    }
}