using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Categorias
{
    public class CategoriaNaoCriada : CatalogoException
    {
        public CategoriaNaoCriada(string message) : base(message)
        {

        }

        public CategoriaNaoCriada() : base("Categoria não criada")
        {

        }
    }
}
