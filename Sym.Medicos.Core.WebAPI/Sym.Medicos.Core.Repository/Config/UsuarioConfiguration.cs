using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sym.Medicos.Core.Domain.Entities;

namespace Sym.Medicos.Core.Repository.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        /// <summary>
        /// Configurando e forçando alguns campos para que na criação eles obedeçam os padrões requeridos
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.IdUsuario);

            //Builder utilizando padrão Fluent
            builder
                .Property(u => u.NomeUsuario)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder
                .Property(u => u.SobreNomeUsuario)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder
                .Property(u => u.Senha)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
        }
    }
}
