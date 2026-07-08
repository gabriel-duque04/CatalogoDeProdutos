using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Categorias
{
    public class CategoriaNaoEncontradaException : CatalogoException
    {
        public CategoriaNaoEncontradaException(string message) : base(message)
        {

        }

        public CategoriaNaoEncontradaException() : base("A categoria não foi encontrada no sistema")
        {

        }
    }
}
