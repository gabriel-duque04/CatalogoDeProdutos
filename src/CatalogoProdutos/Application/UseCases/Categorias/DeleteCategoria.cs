using Application.Ports.PortsRepositories;
using Application.Exceptions.Categorias;
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
    public class DeleteCategoria : IDeleteCategoria
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public DeleteCategoria(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        

        public async Task<bool> ExecutarAsync(int id)
        {
            var existe = await _categoriaRepository.GetCategoriaByIdAsync(id);
            
            
            return existe == null ? throw new CategoriaNaoDeletada("Não foi possível deletar a categoria"): await _categoriaRepository.DeleteCategoriaAsync(id);
        }
    }
}
