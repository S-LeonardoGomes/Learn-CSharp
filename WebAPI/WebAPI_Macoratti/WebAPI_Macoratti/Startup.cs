using APICatalogo.Context;
using APICatalogo.Extensions;
using APICatalogo.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string mySqlConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<ApiLoggingFilter>();
            services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //adiciona o middleware de tratamento de erros
            app.ConfigureExceptionHandler();

            //adiciona o middleware para redirecionar para HTTPS
            app.UseHttpsRedirection();

            //adiciona o middleware de roteamento
            app.UseRouting();

            app.UseAuthentication();

            //adiciona o middleware que habilita a autorização
            app.UseAuthorization();

            //Adiciona o middleware que executa o endpoint do request atual
            app.UseEndpoints(endpoints =>
            {
                //adiciona os endpoints para as Actions dos controladores sem especificar rotas
                endpoints.MapControllers();
            });
        }
    }
}
