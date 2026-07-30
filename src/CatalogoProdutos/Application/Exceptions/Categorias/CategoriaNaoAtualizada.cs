using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Categorias
{
    public class CategoriaNaoAtualizada : CatalogoException
    {
        public CategoriaNaoAtualizada(string message) : base(message)
        {

        }

        public CategoriaNaoAtualizada() : base("Nâo foi possível atualizar a categoria, verifique os campos")
        {

        }
    }
}
