using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sym.Medicos.Core.Domain.Contracts;
using Sym.Medicos.Core.Repository.Context;
using Sym.Medicos.Core.Repository.Repositories;
using Sym.Medicos.Core.API.Utils;

namespace Sym.Medicos.Core.API
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Interface para Injeção de Dependência e Pipeline do Asp.net Core
        /// Arquivo externo para informações de Banco de Dados Etc.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            // Arquivo de configuração que contém a Connection String com Database
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        /// <summary>
        /// Método utilizado para Adicionar Serviços ao Container
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Este método não registrará serviços usados para visualizações ou páginas.
            services.AddControllers();

            //Swagger
            StartupSwagger.ConfigureServices(services);

            // Configuração de Acesso a base de Dados
            // Utilizando UseLazyLoadingProxies para carregamento de relacionamentos automaticos
            var connectionString = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<SymContext>(option =>
                                                option.UseLazyLoadingProxies()
                                                .UseMySql(connectionString,
                                                ServerVersion.AutoDetect(connectionString),
                                                s => s.MigrationsAssembly("Sym.Medicos.Core.Repository")));

            // Mapeamento de Repository e a Classe Concreta de Médicos
            services.AddScoped<IMedicoRepository, MedicoRepository>();

            // Mapeamento de Repository e a Classe Concreta de Consultório
            services.AddScoped<IConsultorioRepository, ConsultorioRepository>();

            // Mapeamento de Repository e a Classe Concreta de Usuário
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Mapeamento de Repository e a Classe Concreta de Vinculo Consultório Médico
            services.AddScoped<IVinculoMedicoConsultorioRepository, VinculoConsultorioMedicoRepository>();
        }

        /// <summary>
        /// Configuração do Pile Line do Asp.Net Core
        /// </summary>
        /// <param name="app">Configuração do Pipe Line</param>
        /// <param name="env">Verificação de Ambiente de Desenvolvimento ou Produção</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Página de Error do desenvolvedor
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                // Página de Exception de Produção
                app.UseExceptionHandler("/Error");

                // Força a utilização do site para utilização do Https
                app.UseHsts();
            }

            // Rediciona a página para Https
            app.UseHttpsRedirection();

            // Utilização de arquivos tipo jpg, bmp, docx, css etc.
            app.UseStaticFiles();

            // utilização de arquivos de estáticos para SPA
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            // utilização de midlware para use de endpoints
            app.UseRouting();

            // utilização de midlware para use de endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            // Configure o App Swagger
            StartupSwagger.Configure(app);
        }
    }
}
