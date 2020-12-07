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
        /// Interface para Inje��o de Depend�ncia e Pipeline do Asp.net Core
        /// Arquivo externo para informa��es de Banco de Dados Etc.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            // Arquivo de configura��o que cont�m a Connection String com Database
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        /// <summary>
        /// M�todo utilizado para Adicionar Servi�os ao Container
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Este m�todo n�o registrar� servi�os usados para visualiza��es ou p�ginas.
            services.AddControllers();

            //Swagger
            StartupSwagger.ConfigureServices(services);

            // Configura��o de Acesso a base de Dados
            // Utilizando UseLazyLoadingProxies para carregamento de relacionamentos automaticos
            var connectionString = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<SymContext>(option =>
                                                option.UseLazyLoadingProxies()
                                                .UseMySql(connectionString,
                                                ServerVersion.AutoDetect(connectionString),
                                                s => s.MigrationsAssembly("Sym.Medicos.Core.Repository")));

            // Mapeamento de Repository e a Classe Concreta de M�dicos
            services.AddScoped<IMedicoRepository, MedicoRepository>();

            // Mapeamento de Repository e a Classe Concreta de Consult�rio
            services.AddScoped<IConsultorioRepository, ConsultorioRepository>();

            // Mapeamento de Repository e a Classe Concreta de Usu�rio
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Mapeamento de Repository e a Classe Concreta de Vinculo Consult�rio M�dico
            services.AddScoped<IVinculoMedicoConsultorioRepository, VinculoConsultorioMedicoRepository>();
        }

        /// <summary>
        /// Configura��o do Pile Line do Asp.Net Core
        /// </summary>
        /// <param name="app">Configura��o do Pipe Line</param>
        /// <param name="env">Verifica��o de Ambiente de Desenvolvimento ou Produ��o</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // P�gina de Error do desenvolvedor
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                // P�gina de Exception de Produ��o
                app.UseExceptionHandler("/Error");

                // For�a a utiliza��o do site para utiliza��o do Https
                app.UseHsts();
            }

            // Rediciona a p�gina para Https
            app.UseHttpsRedirection();

            // Utiliza��o de arquivos tipo jpg, bmp, docx, css etc.
            app.UseStaticFiles();

            // utiliza��o de arquivos de est�ticos para SPA
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            // utiliza��o de midlware para use de endpoints
            app.UseRouting();

            // utiliza��o de midlware para use de endpoints
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
