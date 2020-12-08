using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sym.Medicos.Core.Domain.Entities
{
    public class VinculoMedicoConsultorio : Entidade
    {
        public int IdVinculoMedicoConsultorio { get; set; }

        public int IdMedico { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string CRM { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string NomeMedico { get; set; }

        public int IdConsultorio { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string NomeConsultorio { get; set; }

        /// <summary>
        /// Validações
        /// </summary>
        public override void Validate()
        {
            if (IdConsultorio == 0)
                AdicionarCritica("Id do Consultório é obrigatório.");

            if (!NomeConsultorio.Any())
                AdicionarCritica("Nome do Consultório é obrigatório.");

            if (IdMedico == 0)
                AdicionarCritica("Id do Médico é obrigatório.");

            if (!CRM.Any())
                AdicionarCritica("CRM é obrigatório.");

            if (!NomeMedico.Any())
                AdicionarCritica("Nome do médico é obriga´tório.");
        }
    }
}
