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
    public class DeleteCategoriaUseCase : IDeleteCategoriaUseCase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public DeleteCategoriaUseCase(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        

        public async Task<bool> ExecutarAsync(int id)
        {
            var existe = await _categoriaRepository.GetCategoriaByIdAsync(id);
            
            
            return existe == null ? throw new Exception("Categoria não existe"): await _categoriaRepository.DeleteCategoriaAsync(id);
        }
    }
}
