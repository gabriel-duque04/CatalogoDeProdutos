using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public abstract class CatalogoException : Exception
    {
        protected CatalogoException(string mensagem) : base(mensagem)
        {
            
        }
    }
}
