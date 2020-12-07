using Sym.Medicos.Core.Domain.Entities;

namespace Sym.Medicos.Core.Domain.Contracts
{
    public interface IVinculoMedicoConsultorioRepository : IBaseRepository<VinculoMedicoConsultorio>
    {
        /// <summary>
        /// Método responsável por trazer todos os registros
        /// </summary>
        /// <param name="IdMedico"></param>
        /// <returns></returns>
        VinculoMedicoConsultorio ObterTodos(int IdMedico);
    }
}
