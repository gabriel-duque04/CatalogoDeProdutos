using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutoNaoDeletado : CatalogoException
    {
        public ProdutoNaoDeletado(string message) : base(message)
        {

        }

        public ProdutoNaoDeletado() : base("Ocorreu um erro ao deletar o produto")
        {

        }
    }
}
