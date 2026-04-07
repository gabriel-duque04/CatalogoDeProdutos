using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class ProdutoRequestDTO
    {
        public string _nome { get; set; }
        public string _descricao { get; set; }
        public double _preco { get; set; }
        public int _categoriaId { get; set; }

        public ProdutoRequestDTO(string nome, string descricao, double preco, int categoriaId)
        {
            this._nome = nome;
            this._descricao = descricao;
            this._preco = preco;
            this._categoriaId = categoriaId;
        }
    }
}
