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
        private readonly GetCategoriaByIdUseCase _useCase;

        public GetCategoriaByIdUseCaseTest()
        {
            _categoriaRepoMock = new Mock<ICategoriaRepository>();
            _useCase = new GetCategoriaByIdUseCase(_categoriaRepoMock.Object);
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
    }
}
