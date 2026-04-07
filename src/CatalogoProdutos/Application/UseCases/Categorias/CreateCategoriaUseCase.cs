using Application;
using Application.DTOs.Requests;
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
    public class CreateCategoriaUseCase : ICreateCategoriaUseCase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CreateCategoriaUseCase(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> ExecutarAsync(CategoriaRequestDTO categoria)
        {

            //Validações
            if (String.IsNullOrEmpty(categoria._nome))
                throw new Exception("Nome da é necessário;");

            if (String.IsNullOrEmpty(categoria._descricao))
                throw new Exception("Descriçao é necessária");

            //cria a entidade
            Categoria novaCategoria = new Categoria(categoria._nome, categoria._descricao);


            //Cria no banco por meio do repository
            return await _categoriaRepository.CreateCategoriaAsync(novaCategoria);
        }
    }
}
