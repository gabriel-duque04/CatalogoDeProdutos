using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases;
using Application.Ports.PortsUseCases.Categorias;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categorias
{
    public class GetCategoriaByIdUseCase : IGetCategoriaByIdUseCase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public GetCategoriaByIdUseCase(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> ExecutarAsync(int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);
            //Pega os produtos por categoria
            return categoria == null ? throw new Exception("Categoria não encontrada") : categoria;
        }
    }
}
