using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutoNaoEncontrado : CatalogoException
    {
        public ProdutoNaoEncontrado(string message) : base(message)
        {

        }

        public ProdutoNaoEncontrado() : base("Produto não encontrado")
        {

        }
    }
}
