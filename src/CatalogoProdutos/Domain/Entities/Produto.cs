using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Produto
    {
        private readonly int _id;
        private string _nome;
        private string _descricao;
        private double _preco;
        private int _categoriaId;

        public Produto(string nome, string descricao, double preco, int categoriaId)
        {
            this._nome = nome;
            this._descricao = descricao;
            this._preco = preco;
            this._categoriaId = categoriaId;
        }

        public string GetNome { get { return _nome; } }
        public void SetNome(string nome) { _nome = nome; }

        public string GetDescricao { get { return _descricao; } }
        public void SetDescricao(string descricao) { _descricao = descricao; }

        public double GetPreco { get { return _preco; } }
        public void SetPreco(double preco) { _preco = preco; }

        public int GetCategoriaId { get { return _categoriaId; } }
        public void SetCategoriaId(int categoriaId) { _categoriaId = categoriaId; }


    }
}
