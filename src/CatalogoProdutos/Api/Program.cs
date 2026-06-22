using Application.Ports;
using Application.Ports.PortsRepositories;
using Application.Ports.PortsUseCases.Produtos;
using Domain.Entities;
using Infrastructure.Repositories;
using Application.UseCases.Categorias;
using Application.UseCases.Produtos;
using Application.Ports.PortsUseCases.Categorias;
namespace Api
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
            
            //Use cases produtos
            builder.Services.AddScoped<ICreateProduto, CreateProduto>();
            builder.Services.AddScoped<IDeleteProduto, DeleteProduto>();
            builder.Services.AddScoped<IUpdateProduto, UpdateProduto>();
            builder.Services.AddScoped<IGetProdutosPaginado, GetProdutosPaginado>();
            builder.Services.AddScoped<IGetProdutoById, GetProdutoById>();
            builder.Services.AddScoped<IGetProdutosByCategoriaPaginadoUseCase, GetProdutosByCategoriaPaginado>();

            //Use cases categorias
            builder.Services.AddScoped<ICreateCategoria, CreateCategoria>();
            builder.Services.AddScoped<IDeleteCategoria, DeleteCategoria>();
            builder.Services.AddScoped<IUpdateCategoriaUse, UpdateCategoria>();
            builder.Services.AddScoped<IGetCategoriasPaginadas, GetCategoriasPaginadas>();
            builder.Services.AddScoped<IGetCategoriaById, GetCategoriaById>();

            
            //---------------------------------------------

            //----------------------Swagger

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //-----------------------------
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                
            }

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
