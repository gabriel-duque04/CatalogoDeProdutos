using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.Ports.PortsRepositories
{
    public interface IProdutoRepository
    {
       /// <summary>
       /// Define os contratos para as operações do CRUD dos produtos
       /// </summary>


        //Portas para o GET dos produtos
        Task<Produto?> GetProdutoByIdAsync(int id);
        Task<IEnumerable<Produto>> GetProdutosByCategoriaAsync(int categoriaId);
        Task<IEnumerable<Produto>> GetAllProdutos();



        //Portas para o CREATE dos produtos
        Task<Produto> CreateProdutoAsync(Produto produto);

        
        
        //Portas para o UPDATE de produtos
        Task<Produto> UpdateProdutoAsync(int id, Produto produtoAtualizado);



        //Portas para o DELETE de produtos
        Task<bool> DeleteProdutosAsync(int id);
    }
}
