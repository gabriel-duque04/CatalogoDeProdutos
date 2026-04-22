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
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly string _connectionString;



        /// <summary>
        /// Construtor do repository, pega a string de conexão e salva em uma variável
        /// </summary>
        /// <param name="configuration"></param>
        /// <exception cref="Exception">Se a string for nula</exception>
        public ProdutoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("Conexão não encontrada");
            }
        }
        public async Task<Produto?> GetProdutoByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT * FROM Produtos WHERE Id = @id";

            return await connection.QueryFirstOrDefaultAsync<Produto>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Produto>> GetProdutosByCategoriaPaginadoAsync(int categoriaId,  int pagina, int tamanhoPagina)
        {
            using var connection = new SqlConnection(_connectionString);
            
            var pular = (pagina - 1) * tamanhoPagina;

            var sql = "SELECT * FROM Produtos  WHERE CategoriaID = @CategoriaId ORDER BY Id OFFSET @Pular ROWS FETCH NEXT @Tamanho ROWS ONLY; ";

            return await connection.QueryAsync<Produto>(sql, new { CategoriaId = categoriaId, Pular = pular, Tamanho = tamanhoPagina});
        }

        public async Task<IEnumerable<Produto>> GetProdutosPaginado(int pagina, int tamanhoPagina)
        {
            using var connection = new SqlConnection(_connectionString);

            var pular = (pagina - 1) * tamanhoPagina;

            var sql = "SELECT * FROM Produtos ORDER BY Id OFFSET @Pular ROWS FETCH NEXT @Tamanho ROWS ONLY";

            return await connection.QueryAsync<Produto>(sql, new {Pular = pular, Tamanho = tamanhoPagina});
        }

        public async Task<Produto> CreateProdutoAsync(Produto produto)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "INSERT INTO Produtos (Nome,Descricao,Preco,CategoriaID) OUTPUT INSERTED.* VALUES(@Nome,@Descricao, @Preco,@CategoriaId)";

            return await connection.QuerySingleAsync<Produto>(sql, new {Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                CategoriaId = produto.CategoriaID});
        }

        public async Task<Produto> UpdateProdutoAsync(int id, Produto produtoAtualizado)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "UPDATE Produtos SET Nome = @Nome, Descricao = @Descricao,Preco = @Preco, CategoriaID = @CategoriaId OUTPUT INSERTED.* WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Produto>(sql, new {id, Nome = produtoAtualizado.Nome,
                Descricao = produtoAtualizado.Descricao,
                Preco = produtoAtualizado.Preco,
                CategoriaId = produtoAtualizado.CategoriaID });
        }


        public async Task<bool> DeleteProdutosAsync(int id)
        {
            using var connection =new SqlConnection(_connectionString);

            var sql = "DELETE FROM Produtos WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<bool>(sql, new {id});
        }
    }
}
