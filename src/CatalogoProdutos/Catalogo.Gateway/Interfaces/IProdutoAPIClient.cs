using Application.DTOs.Requests;
using Application.DTOs.Responses;

using Refit;

namespace Catalogo.Gateway.Interfaces
{
    public interface IProdutoAPIClient
    {
        [Get("/api/Produto")]
        Task<IEnumerable<ProdutoResponseDTO>> GetProdutosPaginados([Query] int pagina = 1, [Query] int tamanhoPagina = 10);

        [Get("/api/Produto/{id}")]
        Task<ProdutoResponseDTO> GetProdutoById(int id);


        [Get("/api/Produto/{categoriaId}")]
        Task<IEnumerable<ProdutoResponseDTO>> GetProdutosPorCategoria(int categoriaId, [Query] int pagina = 1, [Query] int tamanhoPagina = 10);


        [Delete("/api/Produto/{id}")]
        Task<bool> DeleteProduto(int id);


        [Put("/api/Produto/{id}")]
        Task<ProdutoResponseDTO> UpdateProduto(int id, ProdutoRequestDTO produtoAtualizar);


        [Post("/api/Produto")]
        Task<ProdutoResponseDTO> CreateProduto([Body]ProdutoRequestDTO produto);


    }
}
