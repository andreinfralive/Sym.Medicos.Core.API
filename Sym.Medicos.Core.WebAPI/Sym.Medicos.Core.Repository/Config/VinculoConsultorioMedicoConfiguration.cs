﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sym.Medicos.Core.Domain.Entities;

namespace Sym.Medicos.Core.Repository.Config
{
    public class VinculoConsultorioMedicoConfiguration : IEntityTypeConfiguration<VinculoMedicoConsultorio>
    {
        /// <summary>
        /// Configurando e forçando alguns campos para que na criação eles obedeçam os padrões requeridos
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<VinculoMedicoConsultorio> builder)
        {
            builder.HasKey(v => v.IdVinculoMedicoConsultorio);

            // Buider utilizando padrão Fluent
            builder
                .Property(v => v.CRM)
                .IsRequired()
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder
                .Property(v => v.NomeMedico)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder
              .Property(v => v.NomeConsultorio)
              .IsRequired()
              .HasColumnType("varchar(100)")
              .HasMaxLength(100);
        }
    }
}
