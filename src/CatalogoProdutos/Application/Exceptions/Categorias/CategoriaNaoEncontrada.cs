using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Categorias
{
    public class CategoriaNaoEncontrada : CatalogoException
    {
        public CategoriaNaoEncontrada(string message) : base(message)
        {

        }

        public CategoriaNaoEncontrada() : base("A categoria não foi encontrada no sistema")
        {

        }
    }
}
