using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Catalogo.Gateway.Interfaces
{
    public interface ICategoriaAPIClient
    {

        [Get("api/Categoria")]
        Task<IEnumerable<CategoriaResponseDTO>> GetCategoriasPaginadas([Query] int pagina, [Query] int tamanhoPagina = 10);


        [Get("api/Categoria/{ id }")]
        Task<CategoriaResponseDTO> GetCategoriaById(int id);


        [HttpDelete("api/Categoria/{ id }")]
        Task<bool> DeleteCategoria(int id);


        [HttpPost("api/Categoria")]
        Task<CategoriaResponseDTO> CreateCategoria([FromBody] CategoriaRequestDTO novaCategoria);


        [HttpPut("api/Categoria/{ id }")]
        Task <CategoriaResponseDTO?> UpdateCategoria(int id, [FromBody] CategoriaRequestDTO categoriaAtualizada);
    }
}
