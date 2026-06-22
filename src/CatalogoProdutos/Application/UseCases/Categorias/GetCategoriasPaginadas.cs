using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases.Categorias;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categorias
{
    public class GetCategoriasPaginadas : IGetCategoriasPaginadas
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public GetCategoriasPaginadas(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ExecutarAsync(int pagina, int tamanhoPagina)
        {
            var resultado = await _categoriaRepository.GetCategoriasPaginadasAsync(pagina, tamanhoPagina);

            return resultado == null ? throw new Exception("Pagina vazia"):resultado;
        }
    }
}
