using Sym.Medicos.Core.Domain.Contracts;
using Sym.Medicos.Core.Domain.Entities;
using Sym.Medicos.Core.Repository.Context;
using System.Linq;

namespace Sym.Medicos.Core.Repository.Repositories
{
    public class VinculoConsultorioMedicoRepository : BaseRespository<VinculoMedicoConsultorio>, IVinculoMedicoConsultorioRepository
    {
        /// <summary>
        /// Método Construtor
        /// </summary>
        public VinculoConsultorioMedicoRepository(SymContext symContext)
                : base(symContext)
        {

        }

        /// <summary>
        /// Método responsável por trazer uma vinculacao do médico
        /// </summary>
        /// <param name="IdMedico">Id do Médico</param>
        /// <returns></returns>
        public VinculoMedicoConsultorio ObterTodos(int IdMedico)
        {
            return SymContext.vinculoMedicoConsultorios.FirstOrDefault(v => v.IdVinculoMedicoConsultorio == IdMedico);
        }
    }
}
