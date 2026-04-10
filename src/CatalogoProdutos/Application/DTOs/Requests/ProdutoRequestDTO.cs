using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class ProdutoRequestDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaID { get; set; }

        public ProdutoRequestDTO(string nome, string descricao, decimal preco, int categoriaId)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
            this.CategoriaID = categoriaId;
        }
    }
}
