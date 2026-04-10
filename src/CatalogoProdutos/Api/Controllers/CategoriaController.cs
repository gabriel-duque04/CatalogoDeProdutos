using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases;
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


        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            var categorias = await _getAllCategoriasUseCase.ExecutarAsync();

            return Ok(categorias);
        }
    }
}
