using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Produto
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

        //Getters
        public string GetNome { get { return _nome; } }
        public string GetDescricao { get { return _descricao; } }
        public double GetPreco { get { return _preco; } }
        public int GetCategoriaId { get { return _categoriaId; } }

        /// <summary>
        /// Método de alteração do nome do produto, verifica se o novo nome é nulo, vazio ou excede o número de caracteres do banco de dados
        /// </summary>
        /// <param name="novoNome"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AlterarNomeProduto(string novoNome)
        {
            if (novoNome == null || novoNome == "" || novoNome.Length > 200)
                throw new ArgumentException("Novo nome para produto inválido");

            this._nome = novoNome;

        }
        /// <summary>
        /// Método de alteração da descrição do produto, verifica se o nova descrição é nula, vazia ou excede o número de caracteres do banco de dados
        /// </summary>
        /// <param name="novaDescricao"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AlterarDescricaoProduto(string novaDescricao)
        {
            if (novaDescricao == null || novaDescricao == "" || novaDescricao.Length > 500)
                throw new ArgumentException("Descrição para produto inválido");

            this._descricao = novaDescricao;

        }
        /// <summary>
        /// Método de alteração do preço do produto, verifica se o preço é negativo
        /// <param name="novoPreco"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AlterarPrecoProduto(double novoPreco)
        {
            if (novoPreco <= 0)
                throw new ArgumentException("Preço inválido");

            this._preco = novoPreco;
        }
        /// <summary>
        /// Método de alteração da categoria 
        /// </summary>
        /// <param name="novaCategoriaId"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AlterarCategoria(int novaCategoriaId)
        {
            if (novaCategoriaId < 0) throw new ArgumentException("Categoria inválida");

            this._categoriaId = novaCategoriaId;
        }
    }
}
