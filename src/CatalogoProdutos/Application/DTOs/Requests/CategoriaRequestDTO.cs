using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class CategoriaRequestDTO
    {
        public string Nome {  get; set; }
        public string Descricao { get; set; }

        public CategoriaRequestDTO(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
        }
    }
}
