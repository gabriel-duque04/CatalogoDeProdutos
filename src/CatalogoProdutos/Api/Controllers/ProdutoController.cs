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
        private readonly IGetAllProdutosUseCase _getAllProdutosUseCase;
        private readonly IGetProdutoByIdUseCase _getProdutoByIdUseCase;
        private readonly IGetProdutosByCategoriaUseCase _getProdutosByCategoriaUseCase;
        private readonly IUpdateProdutoUseCase _updateProdutoUseCase;

        public ProdutoController(ICreateProdutoUseCase createProdutoUseCase,
             IDeleteProdutoUseCase deleteProdutoUseCase,
             IGetAllProdutosUseCase getAllProdutosUseCase,
             IGetProdutoByIdUseCase getProdutoByIdUseCase,
             IGetProdutosByCategoriaUseCase getProdutosByCategoriaUseCase,
             IUpdateProdutoUseCase updateProdutoUseCase)
        {
            this._createProdutoUseCase = createProdutoUseCase;
            this._deleteProdutoUseCase = deleteProdutoUseCase;
            this._getAllProdutosUseCase = getAllProdutosUseCase;
            this._getProdutoByIdUseCase = getProdutoByIdUseCase;
            this._getProdutosByCategoriaUseCase = getProdutosByCategoriaUseCase;
            this._updateProdutoUseCase = updateProdutoUseCase;
        }

        /// <summary>
        /// Post de produtos
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProdutoUseCase(ProdutoRequestDTO produto)
        {
            try 
            {
                var produtoCriado = await _createProdutoUseCase.ExecutarAsync(produto);

                if (produtoCriado == null)
                    return BadRequest("Objeto nulo");

                return Ok(produtoCriado);
            }catch (Exception ex)
            {
                if (ex.Message == "Nome é necessário")
                    return BadRequest(ex.Message);
                if (ex.Message == "Descriçao é necessária")
                    return BadRequest(ex.Message);
                if (ex.Message == "Preço inválido")
                    return BadRequest(ex.Message);
                if (ex.Message == "Categoria não existente")
                    return BadRequest(ex.Message);

                return BadRequest(ex.Message);
            }
            
        }

        
    }
}
