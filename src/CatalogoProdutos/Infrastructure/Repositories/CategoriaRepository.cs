using Application.Ports;
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
    internal class CategoriaRepository : ICategoriaRepository
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


        public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT * FROM Categorias";

            return await connection.QueryAsync<Categoria>(sql);
        }

        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT * FROM Categorias WHERE Id = @Id";

            return await connection.QuerySingleAsync<Categoria>(sql, new { id });
        }

        public async Task<Categoria> UpdateCategoriaAsync(int id, Categoria novaCategoria)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = $"UPDATE Categorias" +
                $" SET Nome = '{novaCategoria.GetNome}', Descricao = '{novaCategoria.GetDescricao}'" +
                $"WHERE Id = @Id";

            return await connection.QuerySingleAsync<Categoria>(sql, new { id });
        }

        public async Task<Categoria> CreateCategoriaAsync(Categoria categoria)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = $"INSERT INTO Categorias (Nome, Descricao)" +
                $"VALUES('{categoria.GetNome}','{categoria.GetDescricao}')";

            return await connection.QuerySingleAsync<Categoria>(sql);
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = $"DELETE FROM Categorias WHERE Id = @Id";

            return await connection.QuerySingleAsync<bool>(sql, new { id });
        }
    }
}
