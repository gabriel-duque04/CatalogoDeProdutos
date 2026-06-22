using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Requests;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases;
using Application.UseCases.Categorias;
using Domain.Entities;
using Moq;
using Xunit;

namespace Application.Tests.CategoriaTests
{
    public class GetCategoriaByIdUseCaseTest
    {
        private readonly Mock<ICategoriaRepository> _categoriaRepoMock;
        private readonly GetCategoriaById _useCase;

        public GetCategoriaByIdUseCaseTest()
        {
            _categoriaRepoMock = new Mock<ICategoriaRepository>();
            _useCase = new GetCategoriaById(_categoriaRepoMock.Object);
        }

        [Fact]
        public async Task ExecutarAsync_RetornaNullQuandoNaoEncontrar()
        {
            int idInexistente = 234234;

            _categoriaRepoMock.Setup(r => r.GetCategoriaByIdAsync(idInexistente))
                            .ReturnsAsync((Categoria)null);

            var ex = await Assert.ThrowsAsync<Exception>(() => _useCase.ExecutarAsync(idInexistente));

            Assert.Equal("Categoria não encontrada", ex.Message);

        }

        [Fact]
        public async Task ExecutarAsync_RetornaCategoria()
        {
            int id = 2;

            Categoria categoriaTeste = new Categoria("Categoria do teste", "Categoria criada para teste");

            _categoriaRepoMock.Setup(r => r.GetCategoriaByIdAsync(id)).ReturnsAsync(categoriaTeste);

            var resultado = await _useCase.ExecutarAsync(id);

            Assert.NotNull(resultado);
            Assert.Equal("Categoria do teste", categoriaTeste.Nome);

            _categoriaRepoMock.Verify(r => r.GetCategoriaByIdAsync(id), Times.Once());
        }
    }
}
