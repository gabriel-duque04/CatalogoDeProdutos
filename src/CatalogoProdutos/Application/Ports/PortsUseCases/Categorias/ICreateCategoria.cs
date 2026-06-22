using Application.DTOs.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.PortsUseCases.Categorias
{
    public interface ICreateCategoria
    {
        Task<Categoria> ExecutarAsync(CategoriaRequestDTO categoria);
    }
}
