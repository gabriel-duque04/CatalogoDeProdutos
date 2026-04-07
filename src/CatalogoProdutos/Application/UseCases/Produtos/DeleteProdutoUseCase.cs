using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Produtos
{
    public class DeleteProdutoUseCase : IDeleteProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public DeleteProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> ExecutarAsync(int id)
        {
            //Validações
            var existe = _produtoRepository.GetProdutoByIdAsync(id);
            if (existe == null)
                throw new Exception("Produto inexistente");

            //deleta o produto
            return await _produtoRepository.DeleteProdutosAsync(id);
        }
    }
}
