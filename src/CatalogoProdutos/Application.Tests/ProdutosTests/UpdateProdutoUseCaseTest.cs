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

namespace Application.Tests.ProdutosTests
{
    public class UpdateProdutoUseCaseTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepoMock;
        private readonly Mock<ICategoriaRepository> _categoriaRepoMock;
        private readonly UpdateProdutoUseCase _useCase;

        public UpdateProdutoUseCaseTest()
        {
            _produtoRepoMock = new Mock<IProdutoRepository>();
            _categoriaRepoMock = new Mock<ICategoriaRepository>();
            _useCase = new UpdateProdutoUseCase(_produtoRepoMock.Object, _categoriaRepoMock.Object);
        }

        [Fact]
        public async Task ExecutarAsync_ProdutoNaoExixte()
        {
            ProdutoRequestDTO request = new ProdutoRequestDTO("Editado", "teste edicao produto", 15, 99);
            int idDoProduto = 50;

            _produtoRepoMock.Setup(r => r.GetProdutoByIdAsync(idDoProduto))
                            .ReturnsAsync((Produto)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _useCase.ExecutarAsync(idDoProduto, request));
            Assert.Equal("Produto inexistente", ex.Message);
        }
    }
}
