# CatalogoDeProdutos API


## Sobre o Projeto

Este sistema foi construído para ser um gerenciador de um catálogo de produtos, permitindo o gerenciamento completo de itens e categorias, o intuito do sistema foi a prática da arquitetura hexagonal, criação de APIs e uso do micro-ORM Dapper.

### Tecnologias e Ferramentas

* **Linguagem:** C# (.NET 8)
* **Banco de Dados:** SQL Server (via Docker)
* **Micro-ORM:** Dapper
* **Arquitetura:** Hexagonal (Ports & Adapters)
* **Containerização:** Docker

---

## Arquitetura e Organização

O projeto utiliza a **Arquitetura Hexagonal**, o que garante que as regras de negócio fiquem isoladas de tecnologias externas.

* **Domain:** Onde moram as entidades (Produto, Categoria).
* **Application:** Contém os Use Cases. É o que intermedia as operações e garante o funcionamento.
* **Infrastructure:** Onde as operações do banco acontece, incluindo repositórios Dapper e scripts de inicialização Docker.
* **Api:** A porta de entrada, onde os Controllers recebem os pedidos.

---

## Configuração do Banco de Dados (Docker)

Para rodar o banco de dados automaticamente com todas as tabelas e dados iniciais, navegue até a pasta:

`src\CatalogoProdutos\Infrastructure\db-create\`

### Windows
1. Construir a imagem:

```console
   docker build -t img-catalogo-db .
```
   
2. Executar o container:
   docker run -p 1433:1433 --name container-catalogo-db -d img-catalogo-db

```console
   docker run -p 1433:1433 --name container-catalogo-db -d img-catalogo-db
```

### Mac (Chips M1, M2 ou M3)
1. Construir a imagem:
   
```console
   docker build --platform linux/amd64 -t img-catalogo-db .
```
3. Executar o container:

```console
  docker run --platform linux/amd64 -p 1433:1433 --name container-catalogo-db -d img-catalogo-db
```


## Configuração do Banco de Dados (Local)

Para rodar localmente:
1. Instale o SQL Server, crie sua instância.
2. Crie o banco e as tabelas usando o [script de criação de tabelas](src/CatalogoProdutos/Infrastructure/DataBase/Scripts/CriacaoBancoETabelas.sql)
3. Se quiser popular o banco use os inserts localizados [aqui](src/CatalogoProdutos/Infrastructure/db-create/setup.sql)
4. Vá até [appsettings.json](src/CatalogoProdutos/Api/appsettings.json) e colocque suas informações na linha `"Default Connetion"`

---

## Dados de Conexão

**!!!IMPORTANTE!!!**

**Após subir o container, aguarde cerca de 30 a 50 segundos para o script de inicialização processar as tabelas.**

**Dados para conexão:**

* Host: localhost,1433
* Usuário: sa
* Senha: CatalogoDeProdutos2304!#
* Banco de Dados: CatalogoDeProdutos

ConnectionString:
`"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=CatalogoDeProdutos;User Id=sa;Password=CatalogoDeProdutos2304!#;TrustServerCertificate=True;"
}`

---

## 🔍 Manutenção

* Verificar logs: docker logs container-catalogo-db
* Resetar banco: docker rm -f container-catalogo-db e execute o comando de "Run" novamente.
