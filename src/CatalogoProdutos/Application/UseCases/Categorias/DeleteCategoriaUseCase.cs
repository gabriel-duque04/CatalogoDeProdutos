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
            //Validações
            var existe = _categoriaRepository.GetCategoriaByIdAsync(id);
            if (existe == null)
                throw new Exception("Categoria inexistente");


            return await _categoriaRepository.DeleteCategoriaAsync(id);
        }
    }
}
