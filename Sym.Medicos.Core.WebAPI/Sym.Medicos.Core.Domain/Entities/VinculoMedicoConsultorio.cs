using System;

namespace Sym.Medicos.Core.Domain.Entities
{
    public class VinculoMedicoConsultorio : Entidade
    {
        public int IdVinculoMedicoConsultorio { get; set; }

        public int IdMedico { get; set; }

        public virtual Medico Medico { get; set; }

        public int IdConsultorio { get; set; }

        public virtual Consultorio Consultorio { get; set; }

        /// <summary>
        /// Validações
        /// </summary>
        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
