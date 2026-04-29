using Application.DTOs.Requests;
using Application.Ports.PortsUseCases.Categorias;
using Application.UseCases.Categorias;
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
        private readonly IGetCategoriasPaginadasUsecase _geCategoriasPaginadasUsecase;

        public CategoriaController(ICreateCategoriaUseCase createCategoriaUseCase,
            IDeleteCategoriaUseCase deleteCategoriaUseCase,
            IUpdateCategoriaUseCase updateCategoriaUseCase,
            IGetCategoriasPaginadasUsecase geCategoriasPaginadasUsecase,
            IGetCategoriaByIdUseCase getCategoriaByIdUseCase)
        {
            _createCategoriaUseCase = createCategoriaUseCase;
            _deleteCategoriaUseCase = deleteCategoriaUseCase;
            _updateCategoriaUseCase = updateCategoriaUseCase;
            _geCategoriasPaginadasUsecase = geCategoriasPaginadasUsecase;
            _getCategoriaByIdUseCase = getCategoriaByIdUseCase;
        }

        /// <summary>
        /// Get de todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategoriaPaginadas([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
        {
            if (pagina <= 0) pagina = 1;
            if (tamanhoPagina <= 0) tamanhoPagina = 10;

            var categorias = await _geCategoriasPaginadasUsecase.ExecutarAsync(pagina, tamanhoPagina);

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
            try
            {
                var categoria = await _getCategoriaByIdUseCase.ExecutarAsync(id);

                if (categoria == null)
                    return BadRequest("Categoria não encontrada");

                return Ok(categoria);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete da categoria pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {

                var foiDeletado = await _deleteCategoriaUseCase.ExecutarAsync(id);

                if (!foiDeletado)
                    return BadRequest("Categoria não encontrada");
                else
                    return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Post de categoria
        /// </summary>
        /// <param name="novaCategoria">Categoria a ser criada</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CategoriaRequestDTO novaCategoria)
        {

            try
            {
                var categoriaCriada = await _createCategoriaUseCase.ExecutarAsync(novaCategoria);

                if (categoriaCriada == null) { return BadRequest("Objeto nulo"); }

                return Ok(categoriaCriada);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
            
            try
            {
                var posAtualizacao = await _updateCategoriaUseCase.ExecutarAsync(id, categoriaAtualizada);

                if (posAtualizacao == null)
                    return BadRequest("Categoria não encontrada");

                return Ok(posAtualizacao);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
