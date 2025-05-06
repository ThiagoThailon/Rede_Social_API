
using RedeSocial.Domain;
using Rede_Social.Infra.Interfaces;
using Rede_Social.Infra.Repositories;
using System.Globalization;
using RedeSocial.Application.Services;


namespace Rede_Social.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IEventoRepository, EventoRepositorie>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositorie>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<PostagemService>();
            builder.Services.AddScoped<IPostagemRepository, PostagemRepositorie>();
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
