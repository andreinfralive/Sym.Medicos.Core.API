using Microsoft.EntityFrameworkCore;
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
        }
    }
}
