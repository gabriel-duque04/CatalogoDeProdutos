using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Categorias
{
    public class CategoriaNaoCriadaException : CatalogoException
    {
        public CategoriaNaoCriadaException(string message) : base(message)
        {

        }

        public CategoriaNaoCriadaException() : base("Categoria não criada")
        {

        }
    }
}
