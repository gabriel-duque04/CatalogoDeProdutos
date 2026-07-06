using Application.DTOs.Requests;
using Application.Handlers;
using Application.Ports.PortsUseCases.Categorias;
using Application.UseCases.Categorias;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaHandler _categoriaHandler;
        
        public CategoriaController(CategoriaHandler categoriaHandler)
        {
            this._categoriaHandler = categoriaHandler;
        }

        /// <summary>
        /// Get de todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategoriaPaginadas([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
        {
            var categorias = await _categoriaHandler.GetCategoriaPaginadas(pagina, tamanhoPagina);

            return Ok(categorias);
        }


        /// <summary>
        /// Get das categorias pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            var categoria = await _categoriaHandler.GetCategoriaById(id);
            return Ok(categoria);
        }


        /// <summary>
        /// Delete da categoria pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var foiDeletado = await _categoriaHandler.DeleteCategoria(id);

            return Ok();
        }

        /// <summary>
        /// Post de categoria
        /// </summary>
        /// <param name="novaCategoria">Categoria a ser criada</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CategoriaRequestDTO novaCategoria)
        {
            var categoriaCriada = await _categoriaHandler.CreateCategoria(novaCategoria);

            return Ok(categoriaCriada);
        }

        /// <summary>
        /// Método para atualizar as categorias
        /// </summary>
        /// <param name="id">id da categoria a ser atualizada</param>
        /// <param name="categoriaAtualizada">Objeto com os novos dados</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CategoriaRequestDTO categoriaAtualizada)
        {
            var posAtualizacao = await _categoriaHandler.UpdateCategoria(id, categoriaAtualizada);

            return Ok(posAtualizacao);
            
        }
    }
}
