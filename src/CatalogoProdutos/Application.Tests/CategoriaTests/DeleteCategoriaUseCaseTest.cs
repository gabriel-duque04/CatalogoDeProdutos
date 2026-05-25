using Application.DTOs.Requests;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases;
using Application.UseCases.Categorias;
using Domain.Entities;
using Moq;
using Xunit;
namespace Application.Tests.CategoriaTests;

public class DeleteCategoriaUseCaseTest
{
    private readonly Mock<ICategoriaRepository> _categoriaRepoMock;
    private readonly DeleteCategoriaUseCase _useCase;

    public DeleteCategoriaUseCaseTest()
    {
        _categoriaRepoMock = new Mock<ICategoriaRepository>();
        _useCase = new DeleteCategoriaUseCase(_categoriaRepoMock.Object);
    }

    [Fact]
    public async Task ExecutarAsync_CategoriaNaoExiste()
    {
        int id = 4444;

        _categoriaRepoMock.Setup(r => r.DeleteCategoriaAsync(id)).ReturnsAsync((bool)false);

        var ex = await Assert.ThrowsAsync<Exception>(() => _useCase.ExecutarAsync(id));
        
        Assert.Equal("Categoria não existe", ex.Message);

    }

    [Fact]
    public async Task ExecutarAsync_DeletaACategoria()
    {
        int id = 3;
        var categoriaFake = new Categoria("Eletrônicos", "Celulares e afins");
        
        _categoriaRepoMock.Setup(r => r.GetCategoriaByIdAsync(id))
            .ReturnsAsync(categoriaFake);

        _categoriaRepoMock.Setup(r => r.DeleteCategoriaAsync(id)).ReturnsAsync((bool)true);

        var resultado = await _useCase.ExecutarAsync(id);

        Assert.True(resultado);
        
        _categoriaRepoMock.Verify(r => r.DeleteCategoriaAsync(id), Times.Once());
    }
}