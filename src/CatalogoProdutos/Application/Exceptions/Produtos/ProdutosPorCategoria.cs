using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutosPorCategoriaExeption : CatalogoException
    {
        public ProdutosPorCategoriaExeption(string message) : base(message)
        {

        }

        public ProdutosPorCategoriaExeption() : base("Produtos não encontrados na categoria")
        {

        }
    }
}
