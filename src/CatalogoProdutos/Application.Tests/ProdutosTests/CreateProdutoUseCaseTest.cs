using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Application.UseCases.Produtos;
using Application.Ports.PortsRepositories;
using Domain.Entities;
using Application.DTOs.Requests;
using Xunit;

namespace Application.Tests.ProdutosTests
{
    public class CreateProdutoUseCaseTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepoMock;
        private readonly Mock<ICategoriaRepository> _categoriaRepoMock;
        private readonly CreateProdutoUseCase _useCase;

        public CreateProdutoUseCaseTest()
        {
            this._produtoRepoMock = new Mock<IProdutoRepository>();
            this._categoriaRepoMock = new Mock<ICategoriaRepository>();
            this._useCase = new CreateProdutoUseCase(_produtoRepoMock.Object, _categoriaRepoMock.Object);
        }

        [Fact]
        public async Task ExecutarAsync_ExceptionQuandoCategoriaInexistente()
        {

            ProdutoRequestDTO request = new ProdutoRequestDTO("Pão de Queijo Congelado", "Um pão de queijo, só que congelado, esquentar antes de comer", 15, 99);
            
            _categoriaRepoMock.Setup(r => r.GetCategoriaByIdAsync(request.CategoriaID)).ReturnsAsync((Categoria)null);


            var ex = await Assert.ThrowsAsync<Exception>(() => _useCase.ExecutarAsync(request));

            Assert.Equal("Categoria não existente", ex.Message);

            _produtoRepoMock.Verify(r => r.CreateProdutoAsync(It.IsAny<Produto>()), Times.Never);
        }

        [Fact]
        public async Task ExecutarAsync_SalvarComSucesso_QuandoDadosValidados()
        {
            var request = new ProdutoRequestDTO("Pão de Queijo Congelado", "Um pão de queijo, só que congelado, esquentar antes de comer", 15, 99);

            var categoriaExistente = new Categoria("Comida de mineiro", "A miô do mundo");

            _categoriaRepoMock.Setup(r => r.GetCategoriaByIdAsync(request.CategoriaID))
                              .ReturnsAsync(categoriaExistente);


            await _useCase.ExecutarAsync(request);


            _produtoRepoMock.Verify(r => r.CreateProdutoAsync(It.IsAny<Produto>()), Times.Once);


        }
    }
}
