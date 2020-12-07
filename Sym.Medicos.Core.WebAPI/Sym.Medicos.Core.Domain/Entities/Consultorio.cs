using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sym.Medicos.Core.Domain.Entities
{
    public class Consultorio : Entidade
    {
        public int IdConsultorio { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string NomeConsultorio { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string EnderecoConsultorio { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string TelefoneConsultorio { get; set; }

        /// <summary>
        /// Validações
        /// </summary>
        public override void Validate()
        {
            if (!NomeConsultorio.Any())
                AdicionarCritica("Nome do consultório é obrigatório.");

            if (!NomeConsultorio.Any())
                AdicionarCritica("Nome do consultório é obrigatório.");

            if (!EnderecoConsultorio.Any())
                AdicionarCritica("Endereço consultório é obrigatório.");

            if (!TelefoneConsultorio.Any())
                AdicionarCritica("Telefone do consultório é obrigatório.");
        }
    }
}
