using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome {get;private set;}
        public string Descricao {get;private set;}
        public decimal Preco {get;private set;}
        public int CategoriaID {get;private set;}
        public bool Ativo {get;private set;}
        public DateTime DataCriacao {get;private set;}

        public Produto(string nome, string descricao, decimal preco, int categoriaId)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
            this.CategoriaID = categoriaId;
            this.Ativo = true;
            this.DataCriacao = DateTime.Now;
        }

        //Construtor usado para o Dapper
        protected Produto() { }

       

        /// <summary>
        /// Método de alteração do nome do produto, verifica se o novo nome é nulo, vazio ou excede o número de caracteres do banco de dados
        /// </summary>
        /// <param name="novoNome"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AlterarNomeProduto(string novoNome)
        {
            if (novoNome == null || novoNome == "" || novoNome.Length > 200)
                throw new ArgumentException("Novo nome para produto inválido");

            this.Nome = novoNome;

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

            this.Descricao = novaDescricao;

        }
        /// <summary>
        /// Método de alteração do preço do produto, verifica se o preço é negativo
        /// <param name="novoPreco"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AlterarPrecoProduto(decimal novoPreco)
        {
            if (novoPreco <= 0)
                throw new ArgumentException("Preço inválido");

            this.Preco = novoPreco;
        }
        /// <summary>
        /// Método de alteração da categoria 
        /// </summary>
        /// <param name="novaCategoriaId"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AlterarCategoria(int novaCategoriaId)
        {
            if (novaCategoriaId < 0) throw new ArgumentException("Categoria inválida");

            this.CategoriaID = novaCategoriaId;
        }
    }
}
