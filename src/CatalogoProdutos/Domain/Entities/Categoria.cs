using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria
    {
        public  int Id { get; private set; }
        public string Nome {get; private set;}
        public string Descricao {get; private set;}
        public DateTime DataCriacao {get; private set;}


        //Construtor padrão da entidade
        public Categoria(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.DataCriacao = DateTime.Now;
        }

        //Construtor usado pelo dapper
        protected Categoria() {}

        //Getters
       


        /// <summary>
        /// Método de alteração do nome da categoria, verifica se o novo nome é nulo, vazio ou excede o número de caracteres do banco de dados
        /// </summary>
        /// <param name="novoNome"></param>
        /// <exception cref="ArgumentException">Retorna se alguma das condições forem falsas</exception>
        public void AlterarNomeCategoria(string novoNome)
        {
            if (novoNome == null || novoNome == "" || novoNome.Length > 200) 
                throw new ArgumentException("Novo nome para categoria inválido");

            this.Nome = novoNome;

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

            this.Descricao = novaDescricao;

        }

    }
}
