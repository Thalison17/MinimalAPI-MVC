using WebApplication1.Context;
using WebApplication1.Contracts;
using WebApplication1.Repository;
using WebApplication1.Services;
using Microsoft.EntityFrameworkCore;

namespace CadastroEnderecoPessoa.CadastroProjeto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            
            builder.Services.AddScoped<ICadastro, CadastroServices>();

            builder.Services.AddScoped<CadastroRepository, CadastroRepository>();

            var app = builder.Build();

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