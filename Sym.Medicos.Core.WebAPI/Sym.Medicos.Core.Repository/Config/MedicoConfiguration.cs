using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sym.Medicos.Core.Domain.Entities;

namespace Sym.Medicos.Core.Repository.Config
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        /// <summary>
        /// Configurando e forçando alguns campos para que na criação eles obedeçam os padrões requeridos
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(c => c.IdMedico);

            // Buider utilizando padrão Fluent
            builder
                .Property(c => c.Crm)
                .IsRequired()
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder
                .Property(c => c.NomeMedico)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder
                .Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder
                .Property(c => c.ValorConsulta)
                .IsRequired()
                .HasColumnType("decimal(19,2)");
        }
    }
}
