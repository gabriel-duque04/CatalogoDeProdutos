using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Categorias
{
    public class CategoriaNaoDeletada : CatalogoException
    {
        public CategoriaNaoDeletada(string message) : base(message)
        {

        }

        public CategoriaNaoDeletada () : base("Erro ao deletar a categoria")
        {

        }
    }
}
