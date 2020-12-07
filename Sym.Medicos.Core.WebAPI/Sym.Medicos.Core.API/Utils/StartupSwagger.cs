using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Sym.Medicos.Core.API.Utils
{
    /// <summary>
    /// Startup do swagger
    /// </summary>
    public class StartupSwagger
    {
        /// <summary>
        /// Configure services swagger
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sym Medicos",
                    Description = "Sistema de Medicos Divinópolis",
                    TermsOfService = new Uri("https://www.Sym.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Sym",
                        Email = "Sym@sym.com.br",
                        Url = new Uri("https://www.sym.com.br"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Sym",
                        Url = new Uri("https://www.sym.com.br")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Configure do swagger
        /// </summary>
        /// <param name="app"></param>
        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medicos API v1");
            });
        }
    }
}
