using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class CategoriaNaoDeletadaException : CatalogoException
    {
        public CategoriaNaoDeletadaException(string message) : base(message)
        {

        }

        public CategoriaNaoDeletadaException () : base("Erro ao deletar a categoria")
        {

        }
    }
}
