using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Application.UseCases.Produtos;
using Application.Ports.PortsRepositories;
using Domain.Entities;
using Xunit;

namespace Application.Tests.ProdutosTests
{
    public class GetProdutoByIdUseCaseTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepoMock;
        private readonly GetProdutoByIdUseCase _useCase;

        public GetProdutoByIdUseCaseTest()
        {
            _produtoRepoMock = new Mock<IProdutoRepository>();
            _useCase = new GetProdutoByIdUseCase(_produtoRepoMock.Object);
        }

        [Fact]
        public async Task ExecutarAsync_ProdutoNaoEncontrado()
        {
            int idInexistente = 992929;

            _produtoRepoMock.Setup(r => r.GetProdutoByIdAsync(idInexistente))
                            .ReturnsAsync((Produto)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _useCase.ExecutarAsync(idInexistente));
            Assert.Equal("Produto não encontrado", ex.Message);
        }

        [Fact]
        public async Task ExecutarAsync_RetornaProduto()
        {
            int idTeste = 1;
            Produto produtoTeste = new Produto("Cafezin", "Hmmmmm cafezin recém passado", 30, 1);

            _produtoRepoMock.Setup(r => r.GetProdutoByIdAsync(idTeste)).ReturnsAsync(produtoTeste);

            var resultado = await _useCase.ExecutarAsync(idTeste);

            Assert.NotNull(resultado);
            Assert.Equal("Cafezin", resultado.Nome);

            _produtoRepoMock.Verify(r => r.GetProdutoByIdAsync(idTeste), Times.Once);

        }
    }
}
