using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases.Categorias;
using Application.Ports.PortsUseCases.Produtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Produtos
{
    public class GetProdutoByIdUseCase : IGetProdutoByIdUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProdutoByIdUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> ExecutarAsync(int id)
        {
            return await _produtoRepository.GetProdutoByIdAsync(id);
        }
    }
}
