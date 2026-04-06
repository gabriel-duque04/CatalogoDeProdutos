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
    public class GetAllCategoriasUseCase : IGetAllCategoriasUseCase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public GetAllCategoriasUseCase(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ExecutarAsync()
        {
            return await _categoriaRepository.GetAllCategoriasAsync();
        }
    }
}
