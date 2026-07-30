using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutoNaoCriado : CatalogoException
    {
        public ProdutoNaoCriado(string message) : base(message)
        {
        }

        public ProdutoNaoCriado() : base("Erro ao criar o produto")
        {
        }
    }
}
