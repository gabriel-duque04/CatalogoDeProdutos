using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutosPorCategoria : CatalogoException
    {
        public ProdutosPorCategoria(string message) : base(message)
        {

        }

        public ProdutosPorCategoria() : base("Produtos não encontrados na categoria")
        {

        }
    }
}
