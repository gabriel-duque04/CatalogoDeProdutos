
using Application.Handlers;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases.Categorias;
using Application.UseCases.Categorias;
using Infrastructure.Repositories;

namespace Categorias.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Repositories
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

            builder.Services.AddScoped<ICreateCategoria, CreateCategoria>();
            builder.Services.AddScoped<IDeleteCategoria, DeleteCategoria>();
            builder.Services.AddScoped<IUpdateCategoriaUse, UpdateCategoria>();
            builder.Services.AddScoped<IGetCategoriasPaginadas, GetCategoriasPaginadas>();
            builder.Services.AddScoped<IGetCategoriaById, GetCategoriaById>();


            builder.Services.AddScoped<CategoriaHandler>();
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
