using Microsoft.EntityFrameworkCore;
using Sym.Medicos.Core.Domain.Entities;
using Sym.Medicos.Core.Repository.Config;

namespace Sym.Medicos.Core.Repository.Context
{
    public class SymContext : DbContext
    {
        /// <summary>
        /// Vinculo Médico com Consultorio
        /// </summary>
        public DbSet<VinculoMedicoConsultorio> vinculoMedicoConsultorios { get; set; }

        /// <summary>
        /// DbSet de Usuarios
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }

        /// <summary>
        /// DbSet de Medicos
        /// </summary>
        public DbSet<Medico> Medicos { get; set; }

        /// <summary>
        /// DbSet de Consultorio
        /// </summary>
        public DbSet<Consultorio> Consultorios { get; set; }

        /// <summary>
        /// Método construtor
        /// </summary>
        public SymContext(DbContextOptions options)
            : base(options)
        {

        }

        /// <summary>
        /// MoldeBuider é utilizado para construir o modelo de contexto
        /// Fazendo referência mapeamento para as classes de mapeamento
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Classes de mapeamento com seus respectivos arquivos de configuração
            modelBuilder.ApplyConfiguration(new MedicoConfiguration());
            modelBuilder.ApplyConfiguration(new ConsultorioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new VinculoConsultorioMedicoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
