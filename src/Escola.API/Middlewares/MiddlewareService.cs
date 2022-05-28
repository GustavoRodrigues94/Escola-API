using System;
using Escola.Application.Consultas;
using Escola.Application.Manipuladores;
using Escola.Domain.Repositorios;
using Escola.Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Escola.API.Middlewares
{
    public static class MiddlewareService
    {
        public static void AdicionarSwagger(IServiceCollection services) => services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Escola API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Gustavo Rodrigues da Silveira",
                        Url = new Uri("https://github.com/GustavoRodrigues94")
                    }
                }));

        public static void AdicionarInjecaoDependecia(IServiceCollection services)
        {
            services.AddScoped<AlunoComandoManipulador, AlunoComandoManipulador>();
            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            services.AddScoped<IAlunoConsultas, AlunoConsultas>();
        }
    }
}
