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
            if (await _produtoRepository.GetProdutoByIdAsync(id) == null)
                throw new Exception("Produto inexistente");

            if (String.IsNullOrEmpty(produtoAtualizar.Nome))
                throw new Exception("Nome é necessário;");

            if (String.IsNullOrEmpty(produtoAtualizar.Descricao))
                throw new Exception("Descriçao é necessária");

            if (produtoAtualizar.Preco <= 0)
                throw new Exception("Preço inválido");

            if (await _categoriaRepository.GetCategoriaByIdAsync(produtoAtualizar.CategoriaID) == null)
                throw new Exception("Categoria não existente");

            Produto produto = new Produto(produtoAtualizar.Nome, produtoAtualizar.Descricao, produtoAtualizar.Preco, produtoAtualizar.CategoriaID);


            return await _produtoRepository.UpdateProdutoAsync(id, produto);
        }
    }
}
