using Sym.Medicos.Core.Domain.Contracts;
using Sym.Medicos.Core.Domain.Entities;
using Sym.Medicos.Core.Repository.Context;
using System.Linq;

namespace Sym.Medicos.Core.Repository.Repositories
{
    public class MedicoRepository : BaseRespository<Medico>, IMedicoRepository
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public MedicoRepository(SymContext symContext)
            : base(symContext)
        {

        }

        /// <summary>
        /// Método responsável por trazer um determinado médico
        /// </summary>
        /// <param name="Crm">CRM do Médico</param>
        /// <param name="NomeMedico">Nome do Médico</param>
        /// <returns></returns>
        public Medico Obter(string Crm, string NomeMedico)
        {
            return SymContext.Medicos.FirstOrDefault(m => m.Crm == Crm && m.NomeMedico == NomeMedico);
        }

        /// <summary>
        /// Método responsável por trazer todos os médicos
        /// </summary>
        /// <param name="NomeMedico"></param>
        /// <returns></returns>
        public Medico ObterTodos(string NomeMedico)
        {
            return SymContext.Medicos.FirstOrDefault(m => m.NomeMedico == NomeMedico);
        }
    }
}
