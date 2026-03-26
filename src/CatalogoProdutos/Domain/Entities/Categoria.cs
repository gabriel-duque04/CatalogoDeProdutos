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

        //Getters
        public string GetNome {  get { return _nome; } }

        public string GetDescricao {  get { return _descricao; } }


        /// <summary>
        /// Método de alteração do nome da categoria, verifica se o novo nome é nulo, vazio ou excede o número de caracteres do banco de dados
        /// </summary>
        /// <param name="novoNome"></param>
        /// <exception cref="ArgumentException">Retorna se alguma das condições forem falsas</exception>
        public void AlterarNomeCategoria(string novoNome)
        {
            if (novoNome == null || novoNome == "" || novoNome.Length > 200) 
                throw new ArgumentException("Novo nome para categoria inválido");

            this._nome = novoNome;

        }

        /// <summary>
        /// Método de alteração da descrição da categoria, verifica se o nova descrição é nula, vazia ou excede o número de caracteres do banco de dados
        /// </summary>
        /// <param name="novaDescricao"></param>
        /// <exception cref="ArgumentException">Retorna se alguma das condições forem falsas</exception>
        public void AlterarDescricaoCategoria(string novaDescricao)
        {
            if (novaDescricao == null || novaDescricao == "" || novaDescricao.Length > 500)
                throw new ArgumentException("Descrição para categoria inválido");

            this._descricao = novaDescricao;

        }

    }
}
