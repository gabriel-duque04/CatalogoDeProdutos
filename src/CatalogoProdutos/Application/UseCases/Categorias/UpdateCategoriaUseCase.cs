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
    public class UpdateCategoriaUseCase : IUpdateCategoriaUseCase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public UpdateCategoriaUseCase(ICategoriaRepository CategoriaRepository)
        {
            _categoriaRepository = CategoriaRepository;
        }

        public async Task<Categoria> ExecutarAsync(int id,CategoriaRequestDTO categoria)
        {


            //Validações
            if (String.IsNullOrEmpty(categoria._nome))
                throw new Exception("Nome da é necessário;");

            if (String.IsNullOrEmpty(categoria._descricao))
                throw new Exception("Descriçao é necessária");

            var existe = _categoriaRepository.GetCategoriaByIdAsync(id);
            if (existe == null)
                throw new Exception("Categoria inexistente");



            //Cria a entidade
            Categoria categoriaAtualizada = new Categoria(categoria._nome, categoria._descricao);

            //Faz a atualização da categoria 
            return await _categoriaRepository.UpdateCategoriaAsync(id, categoriaAtualizada);

            
        }
    }
}
