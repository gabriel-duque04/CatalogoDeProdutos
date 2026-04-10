using Application.DTOs.Requests;
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
    public class UpdateProdutoUseCase : IUpdateProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public UpdateProdutoUseCase(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Produto> ExecutarAsync(int id, ProdutoRequestDTO produtoAtualizar)
        {

            //validações
            if (_produtoRepository.GetProdutoByIdAsync(id) == null)
                throw new Exception("Produto inexistente");

            if (String.IsNullOrEmpty(produtoAtualizar._nome))
                throw new Exception("Nome é necessário;");

            if (String.IsNullOrEmpty(produtoAtualizar._descricao))
                throw new Exception("Descriçao é necessária");

            if (produtoAtualizar._preco <= 0)
                throw new Exception("Preço inválido");

            if (_categoriaRepository.GetCategoriaByIdAsync(produtoAtualizar._categoriaId) == null)
                throw new Exception("Categoria não existente");

            Produto produto = new Produto(produtoAtualizar._nome, produtoAtualizar._descricao, produtoAtualizar._preco, produtoAtualizar._categoriaId);


            return await _produtoRepository.UpdateProdutoAsync(id, produto);
        }
    }
}
