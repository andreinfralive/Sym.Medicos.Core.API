using Sym.Medicos.Core.Domain.Entities;

namespace Sym.Medicos.Core.Domain.Contracts
{
    public interface IVinculoMedicoConsultorioRepository : IBaseRepository<VinculoMedicoConsultorio>
    {
        /// <summary>
        /// Método responsável por trazer todos os registros por CRM de Vinculo de Consultório por Médicos
        /// </summary>
        /// <param name="CRM"></param>
        /// <returns></returns>
        VinculoMedicoConsultorio ObterTodos(string CRM);

        /// <summary>
        /// ObterTodos os vinculos de Médicos com Consultórios
        /// </summary>
        /// <param name="CMR"></param>
        /// <returns></returns>
        int ObterTodosVinculos(string CMR);
    }
}
