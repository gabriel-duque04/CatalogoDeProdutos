using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.PortsUseCases.Produtos
{
    public interface IGetProdutosByCategoriaUseCase
    {
        Task<IEnumerable<Produto>> ExecutarAsync(int categoriaID);
    }
}
