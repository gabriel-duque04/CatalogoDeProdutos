using Application.DTOs.Requests;
using Application.Ports.PortsUseCases.Categorias;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CategoriaHandler
    {
        private readonly ICreateCategoria _createCategoriaUseCase;
        private readonly IDeleteCategoria _deleteCategoriaUseCase;
        private readonly IUpdateCategoriaUse _updateCategoriaUseCase;
        private readonly IGetCategoriaById _getCategoriaByIdUseCase;
        private readonly IGetCategoriasPaginadas _geCategoriasPaginadasUsecase;

        public CategoriaHandler(ICreateCategoria createCategoriaUseCase,
            IDeleteCategoria deleteCategoriaUseCase,
            IUpdateCategoriaUse updateCategoriaUseCase,
            IGetCategoriasPaginadas geCategoriasPaginadasUsecase,
            IGetCategoriaById getCategoriaByIdUseCase)
        {
            _createCategoriaUseCase = createCategoriaUseCase;
            _deleteCategoriaUseCase = deleteCategoriaUseCase;
            _updateCategoriaUseCase = updateCategoriaUseCase;
            _geCategoriasPaginadasUsecase = geCategoriasPaginadasUsecase;
            _getCategoriaByIdUseCase = getCategoriaByIdUseCase;
        }

        /// <summary>
        /// Método chama o usecase e valida as entradas
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="tamanhoPagina"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Categoria>> GetCategoriaPaginadas(int pagina, int tamanhoPagina)
        {
            if (pagina <= 0) pagina = 1;
            if (tamanhoPagina <= 0) tamanhoPagina = 10;

            var categorias = await _geCategoriasPaginadasUsecase.ExecutarAsync(pagina, tamanhoPagina);

            return categorias;
        }



        /// <summary>
        /// Chama o use case e estoura uma exceção caso a entrada esteja errada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">se nâo existir uma categoria com esse Id uma exceção é retornada</exception>
        public async Task<Categoria> GetCategoriaById(int id)
        {

            var categoria = await _getCategoriaByIdUseCase.ExecutarAsync(id);

            if (categoria == null)
                throw new ArgumentException();

            return categoria;
        }


        /// <summary>
        /// Chama o use case e verifica se a categoria foi deletada
        /// </summary>
        /// <param name="id"></param>
        /// <returns>se a categoria foi deletada</returns>
        /// <exception cref="InvalidOperationException">se não foi deletada retorna uma exceção</exception>
        public async Task<bool> DeleteCategoria(int id)
        {
            var foiDeletado = await _deleteCategoriaUseCase.ExecutarAsync(id);

            if (!foiDeletado)
                throw new InvalidOperationException();
            else
                return true;
        }


        /// <summary>
        /// Chama o use case e verifica se criou com sucesso
        /// </summary>
        /// <param name="novaCategoria"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Caso ocorra um erro na criação uma exceção é lançada</exception>
        public async Task<Categoria> CreateCategoria(CategoriaRequestDTO novaCategoria)
        {
            var categoriaCriada = await _createCategoriaUseCase.ExecutarAsync(novaCategoria);

            if (categoriaCriada == null) { throw new ArgumentException(); }

            return categoriaCriada;
        }



        /// <summary>
        /// Chama o use case e verifica se obteve sucesso
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoriaAtualizada"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Caso a atualização nâo dê certo uma exceção é lançada</exception>
        public async Task<Categoria> UpdateCategoria(int id, CategoriaRequestDTO categoriaAtualizada)
        {
            var posAtualizacao = await _updateCategoriaUseCase.ExecutarAsync(id, categoriaAtualizada);

            if (posAtualizacao == null)
                throw new ArgumentException();

            return posAtualizacao;
        }
    }

}
