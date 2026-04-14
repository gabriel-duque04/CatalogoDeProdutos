using Application.DTOs.Requests;
using Application.Ports.PortsUseCases.Categorias;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICreateCategoriaUseCase _createCategoriaUseCase;
        private readonly IDeleteCategoriaUseCase _deleteCategoriaUseCase;
        private readonly IUpdateCategoriaUseCase _updateCategoriaUseCase;
        private readonly IGetCategoriaByIdUseCase _getCategoriaByIdUseCase;
        private readonly IGetAllCategoriasUseCase _getAllCategoriasUseCase;

        public CategoriaController(ICreateCategoriaUseCase createCategoriaUseCase,
            IDeleteCategoriaUseCase deleteCategoriaUseCase,
            IUpdateCategoriaUseCase updateCategoriaUseCase,
            IGetAllCategoriasUseCase getAllCategoriasUseCase,
            IGetCategoriaByIdUseCase getCategoriaByIdUseCase)
        {
            _createCategoriaUseCase = createCategoriaUseCase;
            _deleteCategoriaUseCase = deleteCategoriaUseCase;
            _updateCategoriaUseCase = updateCategoriaUseCase;
            _getAllCategoriasUseCase = getAllCategoriasUseCase;
            _getCategoriaByIdUseCase = getCategoriaByIdUseCase;
        }

        /// <summary>
        /// Get de todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            var categorias = await _getAllCategoriasUseCase.ExecutarAsync();

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
            var categoria = await _getCategoriaByIdUseCase.ExecutarAsync(id);

            if (categoria == null)
                return BadRequest("Categoria não encontrada");

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
            var foiDeletado = await _deleteCategoriaUseCase.ExecutarAsync(id);

            if (!foiDeletado)
                return NotFound("Categoria não encontrada");
            else 
                return NoContent();
        }

        /// <summary>
        /// Post de categoria
        /// </summary>
        /// <param name="novaCategoria">Categoria a ser criada</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CategoriaRequestDTO novaCategoria)
        {
            var categoriaCriada = await _createCategoriaUseCase.ExecutarAsync(novaCategoria);

            if(categoriaCriada == null) { return BadRequest("Objeto nulo"); }

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
            var posAtualizacao = await _updateCategoriaUseCase.ExecutarAsync(id, categoriaAtualizada);

            if(posAtualizacao == null)
            {
                return BadRequest("Categoria não encontrada");
            }

            return Ok(posAtualizacao);
        }
    }
}
