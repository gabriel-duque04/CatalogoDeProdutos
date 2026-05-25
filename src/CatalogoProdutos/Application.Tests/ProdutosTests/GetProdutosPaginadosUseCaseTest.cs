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
    public class GetProdutosPaginadosUseCaseTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepoMock;
        private readonly GetProdutosPaginadoUseCase _useCase;

        public GetProdutosPaginadosUseCaseTest()
        {
            _produtoRepoMock = new Mock<IProdutoRepository>();
            _useCase = new GetProdutosPaginadoUseCase(_produtoRepoMock.Object);
        }


        [Fact]
        public async Task ExecutarAsync_RetornaProdutos()
        {
            int pagina = 1;
            int tamanho = 2;

           
            var listaFake = new List<Produto>
            {
                new Produto("Produto 1", "Desc 1", 1, 10),
                new Produto("Produto 2", "Desc 2", 1, 20)
            };

           
            _produtoRepoMock.Setup(r => r.GetProdutosPaginado(pagina, tamanho))
                            .ReturnsAsync(listaFake);

           
            var resultado = await _useCase.ExecutarAsync(pagina, tamanho);

           
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Equal("Produto 1", resultado.First().Nome);

           
            _produtoRepoMock.Verify(r => r.GetProdutosPaginado(pagina, tamanho), Times.Once);
        }

        [Fact]

        public async Task ExecutArsync_RetornaListaVazia()
        {
            int pagina = 99; 
            int tamanho = 10;

            _produtoRepoMock.Setup(r => r.GetProdutosPaginado(pagina, tamanho))
                            .ReturnsAsync(new List<Produto>()); 

            
            var resultado = await _useCase.ExecutarAsync(pagina, tamanho);

            
            Assert.Empty(resultado); 
            _produtoRepoMock.Verify(r => r.GetProdutosPaginado(pagina, tamanho), Times.Once);
        }
    }
}
