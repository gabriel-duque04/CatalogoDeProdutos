using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Produtos
{
    public class ProdutoNaoAtualizado : CatalogoException
    {
        public ProdutoNaoAtualizado(string message) : base(message)
        {

        }

        public ProdutoNaoAtualizado() : base("Erro ao atualizar o produto")
        {

        }
    }
}
