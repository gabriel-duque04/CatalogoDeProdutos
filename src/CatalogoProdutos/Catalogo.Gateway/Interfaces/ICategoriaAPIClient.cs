using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Refit;

namespace Catalogo.Gateway.Interfaces
{
    public interface ICategoriaAPIClient
    {

        [Get("/api/Categoria")]
        Task<IEnumerable<CategoriaResponseDTO>> GetCategoriasPaginadas([Query] int pagina, [Query] int tamanhoPagina = 10);


        [Get("/api/Categoria/{id}")]
        Task<CategoriaResponseDTO> GetCategoriaById(int id);


        [Delete("/api/Categoria/{id}")]
        Task<bool> DeleteCategoria(int id);


        [Post("/api/Categoria")]
        Task<CategoriaResponseDTO> CreateCategoria([Body] CategoriaRequestDTO novaCategoria);


        [Put("/api/Categoria/{id}")]
        Task <CategoriaResponseDTO?> UpdateCategoria(int id, [Body] CategoriaRequestDTO categoriaAtualizada);
    }
}
