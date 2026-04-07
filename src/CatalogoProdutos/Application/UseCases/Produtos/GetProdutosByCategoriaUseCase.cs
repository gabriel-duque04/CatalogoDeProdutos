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
    public class GetProdutosByCategoriaUseCase : IGetProdutosByCategoriaUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public GetProdutosByCategoriaUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        public async Task<IEnumerable<Produto>> ExecutarAsync(int categoriaID)
        {
            if (_categoriaRepository.GetCategoriaByIdAsync(categoriaID) == null)
                throw new Exception("Categoria inexistente");


            return await _produtoRepository.GetProdutosByCategoriaAsync(categoriaID);
        }

    }
}
