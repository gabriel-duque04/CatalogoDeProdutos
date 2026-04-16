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
            builder.Services.AddScoped<ICreateProdutoUseCase, CreateProdutoUseCase>();
            builder.Services.AddScoped<IDeleteProdutoUseCase, DeleteProdutoUseCase>();
            builder.Services.AddScoped<IUpdateProdutoUseCase, UpdateProdutoUseCase>();
            builder.Services.AddScoped<IGetAllProdutosUseCase, GetAllProdutosUseCase>();
            builder.Services.AddScoped<IGetProdutoByIdUseCase, GetProdutoByIdUseCase>();
            builder.Services.AddScoped<IGetProdutosByCategoriaUseCase, GetProdutosByCategoriaUseCase>();

            //Use cases categorias
            builder.Services.AddScoped<ICreateCategoriaUseCase, CreateCategoriaUseCase>();
            builder.Services.AddScoped<IDeleteCategoriaUseCase, DeleteCategoriaUseCase>();
            builder.Services.AddScoped<IUpdateCategoriaUseCase, UpdateCategoriaUseCase>();
            builder.Services.AddScoped<IGetAllCategoriasUseCase, GetAllCategoriasUseCase>();
            builder.Services.AddScoped<IGetCategoriaByIdUseCase, GetCategoriaByIdUseCase>();

            
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
