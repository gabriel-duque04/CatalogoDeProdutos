using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutoNaoCriadoException : CatalogoException
    {
        public ProdutoNaoCriadoException(string message) : base(message)
        {
        }

        public ProdutoNaoCriadoException() : base("Erro ao criar o produto")
        {
        }
    }
}
