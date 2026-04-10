using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Responses
{
    public class ProdutoResponseDTO
    {
        public string _nome { get; }
        public string _descricao { get; }
        public decimal _preco { get; }
        public int _categoriaId { get; }
        public bool _ativo { get; }

        public ProdutoResponseDTO(string nome, string descricao, decimal preco, int categoriaId)
        {
            this._nome = nome;
            this._descricao = descricao;
            this._preco = preco;
            this._categoriaId = categoriaId;
        }
    }
}