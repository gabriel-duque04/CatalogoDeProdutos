using Application.DTOs.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports.PortsUseCases.Categorias
{
    public interface IUpdateCategoriaUseCase
    {
        Task<Categoria> ExecutarAsync(int id,CategoriaRequestDTO categoria);
    }
}
