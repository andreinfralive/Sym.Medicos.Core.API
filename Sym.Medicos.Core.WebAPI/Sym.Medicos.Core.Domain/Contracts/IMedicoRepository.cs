using Sym.Medicos.Core.Domain.Entities;

namespace Sym.Medicos.Core.Domain.Contracts
{
    public interface IMedicoRepository : IBaseRepository<Medico>
    {
        /// <summary>
        /// Método para obter um determinado Médico
        /// </summary>
        /// <param name="Crm">Crn do Médico</param>
        /// <param name="NomeMedico">Nome do Médito</param>
        /// <returns></returns>
        Medico Obter(string Crm, string NomeMedico);

          /// <summary>
          /// Método responsável por trazer todos os registros
          /// </summary>
          /// <param name="Crm"></param>
          /// <returns></returns>
        Medico ObterTodos(string Crm);
    }
}
