using Application.DTOs.Requests;
using Application.Handlers;
using Application.Ports.PortsUseCases.Produtos;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : CustomControllerBase
    {
        private readonly ProdutoHandler _produtoHandler;
        

        public ProdutoController(ProdutoHandler produtoHandler)
        {
            this._produtoHandler = produtoHandler;
        }

        /// <summary>
        /// Post de produtos
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody]ProdutoRequestDTO produto)
        {
            var produtoCriado = await _produtoHandler.CreateProduto(produto);

            return Ok(produtoCriado);
        }

        
        /// <summary>
        /// Método deleta produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            return Ok(await _produtoHandler.DeleteProduto(id));

        }


        /// <summary>
        /// Método de get para todos produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProdutosPaginado([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
        {
            return Ok(await _produtoHandler.GetProdutosPaginado(pagina, tamanhoPagina));
        }

        
        /// <summary>
        /// Método de get por id de produto
        /// </summary>
        /// <param name="id">id do produto a ser pesquisado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoById(int id)
        {
            return Ok(await _produtoHandler.GetProdutoById(id));
        }
        
        
        /// <summary>
        /// Get de produtos pelo id da categoria
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <returns></returns>
        [HttpGet("porCategoria/{categoriaId}")]
        public async Task<IActionResult> GetProdutosByCategoria(int categoriaId, [FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
        {
            return Ok(await _produtoHandler.GetProdutosByCategoria(categoriaId, pagina, tamanhoPagina));
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
            return Ok(await _produtoHandler.UpdateProduto(id, produtoAtualizar));
        }
        
    }
}
