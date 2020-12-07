using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sym.Medicos.Core.Domain.Entities
{
    public class Medico : Entidade
    {
        public int IdMedico { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Crm { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string NomeMedico { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; }

        [Column(TypeName = "decimal(19,2)")]
        public decimal ValorConsulta { get; set; }

        /// <summary>
        /// Validações
        /// </summary>
        public override void Validate()
        {
            if (!Crm.Any())
                AdicionarCritica("CRM é de preenchimento obrigatório");

            if (!NomeMedico.Any())
                AdicionarCritica("Nome do Médico é de preenchimento obrigatório.");

            if (ValorConsulta == 0)
                AdicionarCritica("Valor da consulta deve ser informado.");
        }
    }
}
