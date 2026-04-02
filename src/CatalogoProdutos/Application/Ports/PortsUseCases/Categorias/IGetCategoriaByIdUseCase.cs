using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.PortsUseCases.Categorias
{
    public interface IGetCategoriaByIdUseCase
    {
        Task<Categoria> ExecutarAsync(int id);
    }
}
