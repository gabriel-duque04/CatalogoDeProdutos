using Application;
using Application.DTOs.Requests;
using Application.Exceptions.Categorias;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases.Categorias;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categorias
{
    public class CreateCategoria : ICreateCategoria
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CreateCategoria(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> ExecutarAsync(CategoriaRequestDTO categoria)
        {

            //Validações
            if (String.IsNullOrEmpty(categoria.Nome))
                throw new CategoriaNaoCriada("Nome da categoria é necessário");

            if (String.IsNullOrEmpty(categoria.Descricao))
                throw new CategoriaNaoCriada("Descrição da categoria é necessária");

            //cria a entidade
            Categoria novaCategoria = new Categoria(categoria.Nome, categoria.Descricao);


            //Cria no banco por meio do repository
            return await _categoriaRepository.CreateCategoriaAsync(novaCategoria);
        }
    }
}
