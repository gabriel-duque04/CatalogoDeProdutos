using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutosPaginadosException : CatalogoException
    {
        public ProdutosPaginadosException(string message) : base(message)
        {

        }

        public ProdutosPaginadosException() : base("Erro ao obter os produtos da lista")
        {

        }
    }
}
