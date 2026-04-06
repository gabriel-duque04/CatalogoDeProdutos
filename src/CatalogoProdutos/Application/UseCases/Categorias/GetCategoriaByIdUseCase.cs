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
            return await _categoriaRepository.GetCategoriaByIdAsync(id);
        }
    }
}
