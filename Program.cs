using ApiExemploCurso.EDs;
using ApiExemploCurso.MAPs;
using Dapper.FluentMap;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore;
namespace ApiExemploCurso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ContatoMap());
            }
                );

            
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // **Importante:** A ordem é crucial!
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();
        }
    }
}