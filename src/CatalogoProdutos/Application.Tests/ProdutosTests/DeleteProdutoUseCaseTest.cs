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
    public class DeleteProdutoUseCaseTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepoMock;
        private readonly DeleteProdutoUseCase _useCase;

        public DeleteProdutoUseCaseTest()
        {
            _produtoRepoMock = new Mock<IProdutoRepository>();
            _useCase = new DeleteProdutoUseCase(_produtoRepoMock.Object);
        }

        [Fact]
        public async Task ExecutarAsync_ProdutoNaoExiste()
        {
            int idInexistente = 99929;

            _produtoRepoMock.Setup(r => r.GetProdutoByIdAsync(idInexistente))
                            .ReturnsAsync((Produto)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _useCase.ExecutarAsync(idInexistente));
            Assert.Equal("Produto inexistente", ex.Message);

            _produtoRepoMock.Verify(r => r.DeleteProdutosAsync(It.IsAny<int>()), Times.Never);
        
        }
    }
}
