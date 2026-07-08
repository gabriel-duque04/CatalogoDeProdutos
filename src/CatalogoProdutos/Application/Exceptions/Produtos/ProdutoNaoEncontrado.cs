using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutoNaoEncontradoException : CatalogoException
    {
        public ProdutoNaoEncontradoException(string message) : base(message)
        {

        }

        public ProdutoNaoEncontradoException() : base("Produto não encontrado")
        {

        }
    }
}
