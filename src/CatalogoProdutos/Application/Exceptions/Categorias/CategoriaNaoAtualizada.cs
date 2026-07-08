using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Categorias
{
    public class CategoriaNaoAtualizadaException : CatalogoException
    {
        public CategoriaNaoAtualizadaException(string message) : base(message)
        {

        }

        public CategoriaNaoAtualizadaException() : base("Nâo foi possível atualizar a categoria, verifique os campos")
        {

        }
    }
}
