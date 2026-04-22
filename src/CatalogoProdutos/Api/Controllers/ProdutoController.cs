using Application.DTOs.Requests;
using Application.Ports.PortsUseCases.Produtos;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ICreateProdutoUseCase _createProdutoUseCase;
        private readonly IDeleteProdutoUseCase _deleteProdutoUseCase;
        private readonly IGetProdutosPaginadoUseCase _getProdutosPaginadoUseCase;
        private readonly IGetProdutoByIdUseCase _getProdutoByIdUseCase;
        private readonly IGetProdutosByCategoriaPaginadoUseCase _getProdutosByCategoriaPaginadoUseCase;
        private readonly IUpdateProdutoUseCase _updateProdutoUseCase;

        public ProdutoController(ICreateProdutoUseCase createProdutoUseCase,
             IDeleteProdutoUseCase deleteProdutoUseCase,
             IGetProdutosPaginadoUseCase getProdutosPaginadoUseCase,
             IGetProdutoByIdUseCase getProdutoByIdUseCase,
             IGetProdutosByCategoriaPaginadoUseCase getProdutosByCategoriaPaginadoUseCase,
             IUpdateProdutoUseCase updateProdutoUseCase)
        {
            this._createProdutoUseCase = createProdutoUseCase;
            this._deleteProdutoUseCase = deleteProdutoUseCase;
            this._getProdutosPaginadoUseCase = getProdutosPaginadoUseCase;
            this._getProdutoByIdUseCase = getProdutoByIdUseCase;
            this._getProdutosByCategoriaPaginadoUseCase = getProdutosByCategoriaPaginadoUseCase;
            this._updateProdutoUseCase = updateProdutoUseCase;
        }

        /// <summary>
        /// Post de produtos
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduto(ProdutoRequestDTO produto)
        {
            try 
            {
                var produtoCriado = await _createProdutoUseCase.ExecutarAsync(produto);

                if (produtoCriado == null)
                    return BadRequest("Objeto nulo");

                return Ok(produtoCriado);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        /// <summary>
        /// Método deleta produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                return Ok(await _deleteProdutoUseCase.ExecutarAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        /// <summary>
        /// Método de get para todos produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProdutosPaginado([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
        {
            try
            {
                return Ok(await _getProdutosPaginadoUseCase.ExecutarAsync(pagina, tamanhoPagina));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
        /// <summary>
        /// Método de get por id de produto
        /// </summary>
        /// <param name="id">id do produto a ser pesquisado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoById(int id)
        {
            try
            {
                return Ok(await _getProdutoByIdUseCase.ExecutarAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
        /// <summary>
        /// Get de produtos pelo id da categoria
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <returns></returns>
        [HttpGet("porCategoria/{categoriaId}")]
        public async Task<IActionResult> GetProdutosByCategoria(int categoriaId, [FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
        {
            try
            {
                return Ok(await _getProdutosByCategoriaPaginadoUseCase.ExecutarAsync(categoriaId,pagina, tamanhoPagina));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
        /// <summary>
        /// Método de update para produto por id
        /// </summary>
        /// <param name="id">id do produto a ser atualizado</param>
        /// <param name="produtoAtualizar">produto com dados novos</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, ProdutoRequestDTO produtoAtualizar)
        {
            try
            {
                return Ok(await _updateProdutoUseCase.ExecutarAsync(id, produtoAtualizar));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}
