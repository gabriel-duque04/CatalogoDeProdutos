using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Categoria
    {
        private readonly int _id;
        private string _nome;
        private string _descricao;

        public Categoria(string nome, string descricao)
        {
            this._nome = nome;
            this._descricao = descricao;
        }

        //Getters & Setters
        public string GetNome {  get { return _nome; } }
        public void SetNome(string nome) { this._nome = nome; }

        public string GetDescricao {  get { return _descricao; } }
        public void SetDescricao(string descricao) {  this._descricao = descricao;}


    }
}
