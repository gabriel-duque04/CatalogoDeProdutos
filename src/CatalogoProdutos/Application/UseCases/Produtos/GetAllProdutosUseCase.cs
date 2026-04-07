using Application.DTOs.Responses;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases.Produtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Produtos
{
    public class GetAllProdutosUseCase : IGetAllProdutosUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetAllProdutosUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ExecutarAsync()
        {
            return await _produtoRepository.GetAllProdutos();
        }
    }
}
