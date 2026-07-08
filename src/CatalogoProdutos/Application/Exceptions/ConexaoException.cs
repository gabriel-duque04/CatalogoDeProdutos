using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ConexaoException : CatalogoException
    {
        public ConexaoException() : base("Erro na conexão com o banco de dados")
        {

        }
    }
}
