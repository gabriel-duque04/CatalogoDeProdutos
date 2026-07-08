using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutoNaoDeletadoException : CatalogoException
    {
        public ProdutoNaoDeletadoException(string message) : base(message)
        {

        }

        public ProdutoNaoDeletadoException() : base("Ocorreu um erro ao deletar o produto")
        {

        }
    }
}
