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
            Categoria novaCategoria = new Categoria(categoria._nome, categoria._descricao);

            return await _categoriaRepository.CreateCategoriaAsync(novaCategoria);
        }
    }
}
