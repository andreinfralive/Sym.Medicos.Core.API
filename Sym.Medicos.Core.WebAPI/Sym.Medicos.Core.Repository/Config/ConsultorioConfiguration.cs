using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sym.Medicos.Core.Domain.Entities;

namespace Sym.Medicos.Core.Repository.Config
{
    public class ConsultorioConfiguration : IEntityTypeConfiguration<Consultorio>
    {
        /// <summary>
        /// Configurando e forçando alguns campos para que na criação eles obedeçam os padrões requeridos
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Consultorio> builder)
        {
            builder.HasKey(c => c.IdConsultorio);

            // Buider utilizando padrão Fluent
            builder
                .Property(c => c.NomeConsultorio)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder
                .Property(c => c.EnderecoConsultorio)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            builder
                .Property(c => c.TelefoneConsultorio)
                .IsRequired()
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);
        }
    }
}
