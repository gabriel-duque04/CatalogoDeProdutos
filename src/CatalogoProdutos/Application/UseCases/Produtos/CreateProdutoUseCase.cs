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

            Produto novòProduto = new Produto(produto._nome, produto._descricao, produto._preco, produto._categoriaId);

        }
    }
}
