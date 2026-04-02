using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.PortsUseCases.Produtos
{
    public interface IDeleteProdutoUseCase
    {
        Task<Produto> ExecutarAsync(int id);
    }
}
