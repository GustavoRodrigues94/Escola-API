using Escola.API.Middlewares;
using Escola.Infra.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Escola.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            AdicionarMiddlewares(services);
            AdicionarContexto(services);
        }

        private void AdicionarContexto(IServiceCollection services)
        {
            services.AddDbContext<EscolaContexto>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AdicionarMiddlewares(IServiceCollection services)
        {
            MiddlewareService.AdicionarSwagger(services);
            MiddlewareService.AdicionarInjecaoDependecia(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Escola.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
