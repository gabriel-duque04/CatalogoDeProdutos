using Application.DTOs.Requests;
using Application.Exceptions.Produtos;
using Application.Ports.PortsUseCases.Produtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class ProdutoHandler
    {
        private readonly ICreateProduto _createProdutoUseCase;
        private readonly IDeleteProduto _deleteProdutoUseCase;
        private readonly IGetProdutosPaginado _getProdutosPaginadoUseCase;
        private readonly IGetProdutoById _getProdutoByIdUseCase;
        private readonly IGetProdutosByCategoriaPaginadoUseCase _getProdutosByCategoriaPaginadoUseCase;
        private readonly IUpdateProduto _updateProdutoUseCase;

        public ProdutoHandler(ICreateProduto createProdutoUseCase,
             IDeleteProduto deleteProdutoUseCase,
             IGetProdutosPaginado getProdutosPaginadoUseCase,
             IGetProdutoById getProdutoByIdUseCase,
             IGetProdutosByCategoriaPaginadoUseCase getProdutosByCategoriaPaginadoUseCase,
             IUpdateProduto updateProdutoUseCase)
        {
            this._createProdutoUseCase = createProdutoUseCase;
            this._deleteProdutoUseCase = deleteProdutoUseCase;
            this._getProdutosPaginadoUseCase = getProdutosPaginadoUseCase;
            this._getProdutoByIdUseCase = getProdutoByIdUseCase;
            this._getProdutosByCategoriaPaginadoUseCase = getProdutosByCategoriaPaginadoUseCase;
            this._updateProdutoUseCase = updateProdutoUseCase;
        }

        /// <summary>
        /// Método de criação de produtos
        /// </summary>
        /// <param name="produto">recebe DTO de criação de produtos <param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Caso o produto não seja criado</exception>
        public async Task<Produto> CreateProduto(ProdutoRequestDTO produto)
        {
            var produtoCriado = await _createProdutoUseCase.ExecutarAsync(produto);

            if (produtoCriado == null)
                throw new ProdutoNaoCriado();

            return produtoCriado;
        }


        /// <summary>
        /// Método para deletar produtos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProduto(int id)
        {
            return await _deleteProdutoUseCase.ExecutarAsync(id) == true ? true : throw new ProdutoNaoDeletado();
        }

        /// <summary>
        /// Retorna produtos de forma paginada
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="tamanhoPagina"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">caso ocorra um erro </exception>
        public async Task<IEnumerable<Produto>> GetProdutosPaginado( int pagina, int tamanhoPagina)
        {
            var produtos = await _getProdutosPaginadoUseCase.ExecutarAsync(pagina, tamanhoPagina);
            if(produtos == null)
                throw new ProdutoNaoEncontrado();
            else
                return produtos;
        }


        /// <summary>
        /// Retorna produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Produto> GetProdutoById(int id)
        {
            var produto = await _getProdutoByIdUseCase.ExecutarAsync(id);

            if(produto == null)
                throw new ProdutoNaoEncontrado();
            else
                return produto;
        }

        /// <summary>
        /// Retorna os produtos por categoria também de forma paginada
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <param name="pagina"></param>
        /// <param name="tamanhoPagina"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">caso ocorra um erro</exception>
        public async Task<IEnumerable<Produto>> GetProdutosByCategoria(int categoriaId, int pagina = 1, int tamanhoPagina = 10)
        {
            var produtos = await _getProdutosByCategoriaPaginadoUseCase.ExecutarAsync(categoriaId, pagina, tamanhoPagina);

            if( produtos == null)
                throw new ProdutosPorCategoria();
            else
                return produtos;
        }


        /// <summary>
        /// Atualiza produto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produtoAtualizar"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">caso ocorroa um erro</exception>
        public async Task<Produto> UpdateProduto(int id, ProdutoRequestDTO produtoAtualizar)
        {
            var produto = await _updateProdutoUseCase.ExecutarAsync(id, produtoAtualizar);
            
            
            if (produto == null)
                throw new ProdutoNaoAtualizado();
            else
                return produto;
        }
    }
    
}
