using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Responses
{
    public class CategoriaResponseDTO
    {
        public string _nome { get; set; }
        public string _descricao { get; set; }

        public CategoriaResponseDTO(string nome, string descricao)
        {
            this._nome = nome;
            this._descricao = descricao;
        }
    }
}
