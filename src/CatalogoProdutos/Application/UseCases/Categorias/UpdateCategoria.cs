using Application.DTOs.Requests;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases.Categorias;
using Domain.Entities;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions.Categorias;

namespace Application.UseCases.Categorias
{
    public class UpdateCategoria : IUpdateCategoriaUse
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public UpdateCategoria(ICategoriaRepository CategoriaRepository)
        {
            _categoriaRepository = CategoriaRepository;
        }

        public async Task<Categoria> ExecutarAsync(int id,CategoriaRequestDTO categoria)
        {


            //Validações
            if (String.IsNullOrEmpty(categoria.Nome))
                throw new CategoriaNaoAtualizada("Nome da categoria é necessário;");

            if (String.IsNullOrEmpty(categoria.Descricao))
                throw new CategoriaNaoAtualizada("Descriçao da categoria é necessária");

            var existe = await _categoriaRepository.GetCategoriaByIdAsync(id);
            if (existe == null)
                throw new CategoriaNaoAtualizada("Categoria inexistente");



            //Cria a entidade
            Categoria categoriaAtualizada = new Categoria(categoria.Nome, categoria.Descricao);

            //Faz a atualização da categoria 
            return await _categoriaRepository.UpdateCategoriaAsync(id, categoriaAtualizada);

            
        }
    }
}
