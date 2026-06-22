using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases;
using Application.UseCases.Categorias;
using Application.UseCases.Produtos;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.CategoriaTests
{
    public class GetCategoriasPaginadasUseCaseTest
    {
        private readonly Mock<ICategoriaRepository> _categoriaRepoMock;
        private readonly GetCategoriasPaginadas _useCase;

        public GetCategoriasPaginadasUseCaseTest()
        {
            _categoriaRepoMock = new Mock<ICategoriaRepository>();
            _useCase = new GetCategoriasPaginadas(_categoriaRepoMock.Object);
        }

        [Fact]
        public async Task ExecutarAsync_PaginaVazia()
        {
            _categoriaRepoMock.Setup(r => r.GetCategoriasPaginadasAsync(98, 10)).ReturnsAsync((IEnumerable<Categoria>)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _useCase.ExecutarAsync(98,10));

            Assert.Equal("Pagina vazia", ex.Message);
        }
    }
}
