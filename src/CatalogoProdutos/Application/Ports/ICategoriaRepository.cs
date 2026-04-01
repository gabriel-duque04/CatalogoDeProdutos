using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Ports
{
    public interface ICategoriaRepository
    {
        /// <summary>
        /// Define os contratos para as operações do CRUD das categorias
        /// </summary>
        /// <returns></returns>



        //Ports para o GET das Categorias
        Task<IEnumerable<Categoria>> GetAllCategoriasAsync();
        Task<Categoria?> GetCategoriaByIdAsync(int id);


        //Ports para o UPDATE das Categorias
        Task<Categoria> UpdateCategoriaAsync(int id, Categoria novaCategoria);


        //Ports para o CREATE das Categorias
        Task<Categoria> CreateCategoriaAsync(Categoria categoria);


        //Ports para o DELETE das Categorias
        Task<bool> DeleteCategoriaAsync(int id);

        
    }
}
