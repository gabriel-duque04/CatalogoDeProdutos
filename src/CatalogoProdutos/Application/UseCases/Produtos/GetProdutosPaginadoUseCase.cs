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
    public class GetProdutosPaginadoUseCase : IGetProdutosPaginadoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProdutosPaginadoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ExecutarAsync(int pagina, int tamanhoPagina)
        {
            return await _produtoRepository.GetProdutosPaginado(pagina, tamanhoPagina);
        }
    }
}
