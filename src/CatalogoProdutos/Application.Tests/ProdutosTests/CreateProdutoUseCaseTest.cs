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
using Xunit;

namespace Application.Tests.ProdutosTests
{
    public class CreateProdutoUseCaseTest
    {
        private readonly Mock<IProdutoRepository> _produtoRepoMock;
        private readonly Mock<ICategoriaRepository> _categoriaRepoMock;
        private readonly CreateProdutoUseCase _useCase;

        public CreateProdutoUseCaseTest()
        {
            this._produtoRepoMock = new Mock<IProdutoRepository>();
            this._categoriaRepoMock = new Mock<ICategoriaRepository>();
            this._useCase = new CreateProdutoUseCase(_produtoRepoMock.Object, _categoriaRepoMock.Object);
        }


    }
}
