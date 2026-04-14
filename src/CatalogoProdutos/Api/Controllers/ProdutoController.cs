using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Ports.PortsUseCases;
using Application.Ports.PortsUseCases.Produtos;
using Application.UseCases.Categorias;
using Application.UseCases.Produtos;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly CreateProdutoUseCase _createProdutoUseCase;
        private readonly DeleteProdutoUseCase _deleteProdutoUseCase;
        private readonly GetAllProdutosUseCase _getAllProdutosUseCase;
        private readonly GetProdutoByIdUseCase _getProdutoByIdUseCase;
        private readonly GetProdutosByCategoriaUseCase _getProdutosByCategoriaUseCase;
        private readonly UpdateProdutoUseCase _updateProdutoUseCase;

        public ProdutoController(CreateProdutoUseCase createProdutoUseCase,
             DeleteProdutoUseCase deleteProdutoUseCase,
             GetAllProdutosUseCase getAllProdutosUseCase,
             GetProdutoByIdUseCase getProdutoByIdUseCase,
             GetProdutosByCategoriaUseCase getProdutosByCategoriaUseCase,
             UpdateProdutoUseCase updateProdutoUseCase)
        {
            this._createProdutoUseCase = createProdutoUseCase;
            this._deleteProdutoUseCase = deleteProdutoUseCase;
            this._getAllProdutosUseCase = getAllProdutosUseCase;
            this._getProdutoByIdUseCase = getProdutoByIdUseCase;
            this._getProdutosByCategoriaUseCase = getProdutosByCategoriaUseCase;
            this._updateProdutoUseCase = updateProdutoUseCase;

        }
    }
}
