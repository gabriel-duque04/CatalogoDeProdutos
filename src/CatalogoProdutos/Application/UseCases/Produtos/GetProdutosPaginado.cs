using Application.DTOs.Responses;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases.Produtos;
using Domain.Entities;
using Application.Exceptions.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Produtos
{
    public class GetProdutosPaginado : IGetProdutosPaginado
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProdutosPaginado(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ExecutarAsync(int pagina, int tamanhoPagina)
        {
            var produtos = await _produtoRepository.GetProdutosPaginado(pagina, tamanhoPagina);
            return produtos == null ? throw new ProdutosPaginados("Pagina de produtos vazios") : produtos;
        }
    }
}
