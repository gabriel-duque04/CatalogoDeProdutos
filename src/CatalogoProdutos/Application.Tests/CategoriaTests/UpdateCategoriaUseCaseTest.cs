using Application.DTOs.Requests;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases;
using Application.UseCases.Categorias;
using Domain.Entities;
using Moq;
using Xunit;

namespace Application.Tests.CategoriaTests;

public class UpdateCategoriaUseCaseTest
{
    private readonly Mock<ICategoriaRepository> _categoriaRepoMock;
    private readonly UpdateCategoria _useCase;

    public UpdateCategoriaUseCaseTest()
    {
        _categoriaRepoMock = new Mock<ICategoriaRepository>();
        _useCase = new UpdateCategoria(_categoriaRepoMock.Object);
    }

    [Fact]
    public async Task ExecutarAsync_NomeVazio()
    {
        int id = 1;
        var request = new CategoriaRequestDTO { Nome = "", Descricao = "Eletrônicos bons" };

        
        var ex = await Assert.ThrowsAsync<Exception>(() => _useCase.ExecutarAsync(id, request));
        Assert.Equal("Nome da é necessário;", ex.Message);
    }

    [Fact]
    public async Task ExecutarAsync_CategoriaNaoExiste()
    {
        int idInexistente = 99;
        var request = new CategoriaRequestDTO { Nome = "Games", Descricao = "Consoles e jogos" };

        
        _categoriaRepoMock.Setup(r => r.GetCategoriaByIdAsync(idInexistente))
            .ReturnsAsync((Categoria)null);

        
        var ex = await Assert.ThrowsAsync<Exception>(() => _useCase.ExecutarAsync(idInexistente, request));
        Assert.Equal("Categoria inexistente", ex.Message);

        
        _categoriaRepoMock.Verify(r => r.UpdateCategoriaAsync(It.IsAny<int>(), It.IsAny<Categoria>()), Times.Never);
    }

    [Fact]
    public async Task ExecutarAsync_AtualizadaACategoria()
    {
        int idExistente = 1;
        var request = new CategoriaRequestDTO { Nome = "Cozinha", Descricao = "Panelas e Pratos" };
            
        var categoriaDoBancoFake = new Categoria("Cozinha Velha", "Coisas antigas");
        var categoriaAtualizadaFake = new Categoria(request.Nome, request.Descricao);
        
        _categoriaRepoMock.Setup(r => r.GetCategoriaByIdAsync(idExistente))
            .ReturnsAsync(categoriaDoBancoFake);
        
        _categoriaRepoMock.Setup(r => r.UpdateCategoriaAsync(idExistente, It.IsAny<Categoria>()))
            .ReturnsAsync(categoriaAtualizadaFake);
        
        var resultado = await _useCase.ExecutarAsync(idExistente, request);
        
        Assert.NotNull(resultado);
        Assert.Equal("Cozinha", resultado.Nome);
        
        _categoriaRepoMock.Verify(r => r.UpdateCategoriaAsync(idExistente, It.IsAny<Categoria>()), Times.Once);
    }
}