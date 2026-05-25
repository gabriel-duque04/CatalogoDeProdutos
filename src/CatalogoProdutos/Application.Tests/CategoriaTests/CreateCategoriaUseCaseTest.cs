using Application.DTOs.Requests;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases;
using Application.UseCases.Categorias;
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
    public class CreateCategoriaUseCaseTest
    {
        private readonly Mock<ICategoriaRepository> _categoriaRepoMock;
        private readonly CreateCategoriaUseCase _useCase;

        public CreateCategoriaUseCaseTest()
        {
            _categoriaRepoMock = new Mock<ICategoriaRepository>();
            _useCase = new CreateCategoriaUseCase(_categoriaRepoMock.Object);
        }

        [Fact]
        public async Task ExecutarAsync_NomeNulo()
        {
            var request = new CategoriaRequestDTO { Nome = "", Descricao = "Teste" };

           
            var ex = await Assert.ThrowsAsync<Exception>(() => _useCase.ExecutarAsync(request));
            Assert.Equal("Nome da é necessário;", ex.Message);

           
            _categoriaRepoMock.Verify(r => r.CreateCategoriaAsync(It.IsAny<Categoria>()), Times.Never);
        }

        [Fact]
        public async Task ExecutarAsync_CriarCategoria()
        {
            var request = new CategoriaRequestDTO { Nome = "Eletrônicos", Descricao = "Celulares e PCs" };




            _categoriaRepoMock.Setup(r => r.CreateCategoriaAsync(It.IsAny<Categoria>()))
                              .ReturnsAsync(new Categoria(request.Nome, request.Descricao));


            await _useCase.ExecutarAsync(request);

           
           
            _categoriaRepoMock.Verify(r => r.CreateCategoriaAsync(It.Is<Categoria>(c => c.Nome == request.Nome)), Times.Once);
        }
    }
    
}
