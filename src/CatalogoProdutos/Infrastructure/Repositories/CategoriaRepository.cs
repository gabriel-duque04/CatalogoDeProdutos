using Application.Ports.PortsRepositories;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _connectionString;



        /// <summary>
        /// Construtor do repository, pega a string de conexão e salva em uma variável
        /// </summary>
        /// <param name="configuration"></param>
        /// <exception cref="Exception">Se a string for nula</exception>
        public CategoriaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            if(string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("Conexão não encontrada");
            }
        }


        public async Task<IEnumerable<Categoria>> GetCategoriasPaginadasAsync(int pagina, int tamanhoPagina)
        {
            using var connection = new SqlConnection(_connectionString);

            var pular = (pagina - 1) * tamanhoPagina;

            var sql = "SELECT * FROM Categorias ORDER BY Id OFFSET @Pular ROWS FETCH NEXT @Tamanho ROWS ONLY;";

            return await connection.QueryAsync<Categoria>(sql, new {Pular = pular, Tamanho = tamanhoPagina});
        }

        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT * FROM Categorias WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Categoria>(sql, new { id });
        }

        public async Task<Categoria> UpdateCategoriaAsync(int id, Categoria novaCategoria)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "UPDATE Categorias  SET Nome = @Nome, Descricao = @Descricao OUTPUT INSERTED.*  WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Categoria>(sql, new { Id = id, Nome = novaCategoria.Nome, Descricao = novaCategoria.Descricao });
        }

        public async Task<Categoria> CreateCategoriaAsync(Categoria categoria)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "INSERT INTO Categorias (Nome, Descricao) OUTPUT inserted.* VALUES(@Nome,@Descricao)";

            return await connection.QuerySingleAsync<Categoria>(sql, new { Nome = categoria.Nome, Descricao = categoria.Descricao });
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "DELETE FROM Categorias WHERE Id = @Id";

            var resultado = await connection.ExecuteAsync(sql, new { Id = id });

            return (resultado > 0);
        }
    }
}
