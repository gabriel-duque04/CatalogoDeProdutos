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
    public class CreateProdutoUseCase : ICreateProdutoUseCase
    {

        private readonly IProdutoRepository _produtoRepository;

        private readonly ICategoriaRepository _categoriaRepository;


        public CreateProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> ExecutarAsync(ProdutoRequestDTO produto)
        {
            //Validações
            if (String.IsNullOrEmpty(produto._nome))
                throw new Exception("Nome é necessário;");

            if (String.IsNullOrEmpty(produto._descricao))
                throw new Exception("Descriçao é necessária");

            if (produto._preco <= 0)
                throw new Exception("Preço inválido");

            if (_categoriaRepository.GetCategoriaByIdAsync(produto._categoriaId) == null)
                throw new Exception("Categoria não existente");


            Produto novoProduto = new Produto(produto._nome, produto._descricao, produto._preco, produto._categoriaId);


            return await _produtoRepository.CreateProdutoAsync(novoProduto);



        }
    }
}
