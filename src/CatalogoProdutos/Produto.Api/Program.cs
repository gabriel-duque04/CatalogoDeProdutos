
using Application.Handlers;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases.Produtos;
using Application.UseCases.Produtos;
using Infrastructure.Repositories;

namespace Produto.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //----------------------Injeção das dependencias 

            //Repositories
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

            builder.Services.AddScoped<ProdutoHandler>();

            //Use cases produtos
            builder.Services.AddScoped<ICreateProduto, CreateProduto>();
            builder.Services.AddScoped<IDeleteProduto, DeleteProduto>();
            builder.Services.AddScoped<IUpdateProduto, UpdateProduto>();
            builder.Services.AddScoped<IGetProdutosPaginado, GetProdutosPaginado>();
            builder.Services.AddScoped<IGetProdutoById, GetProdutoById>();
            builder.Services.AddScoped<IGetProdutosByCategoriaPaginadoUseCase, GetProdutosByCategoriaPaginado>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
