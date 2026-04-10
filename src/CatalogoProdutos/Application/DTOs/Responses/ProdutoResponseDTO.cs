using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Responses
{
    public class ProdutoResponseDTO
    {
        public string Nome { get; }
        public string Descricao { get; }
        public decimal Preco { get; }
        public int CategoriaID { get; }
        public bool Ativo { get; }

        public ProdutoResponseDTO(string nome, string descricao, decimal preco, int categoriaId)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
            this.CategoriaID = categoriaId;
        }
    }
}