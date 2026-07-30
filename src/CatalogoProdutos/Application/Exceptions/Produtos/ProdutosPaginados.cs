using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutosPaginados : CatalogoException
    {
        public ProdutosPaginados(string message) : base(message)
        {

        }

        public ProdutosPaginados() : base("Erro ao obter os produtos da lista")
        {

        }
    }
}
