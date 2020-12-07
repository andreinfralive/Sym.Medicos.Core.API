using Sym.Medicos.Core.Domain.Contracts;
using Sym.Medicos.Core.Domain.Entities;
using Sym.Medicos.Core.Repository.Context;
using System.Linq;

namespace Sym.Medicos.Core.Repository.Repositories
{
    public class ConsultorioRepository : BaseRespository<Consultorio>, IConsultorioRepository
    {
        /// <summary>
        /// Construtor Consultorios
        /// </summary>
        public ConsultorioRepository(SymContext symContext)
                : base(symContext)
        {

        }

        /// <summary>
        /// Método para obter um determinado registro de consultório
        /// </summary>
        /// <param name="NomeConsultorio">Nome do Consultorio</param>
        /// <param name="EnderecoConsultorio">Endereço do Consultorio</param>
        /// <returns></returns>
        public Consultorio Obter(string NomeConsultorio, string EnderecoConsultorio)
        {
            return SymContext.Consultorios.FirstOrDefault(c => c.NomeConsultorio == NomeConsultorio && c.EnderecoConsultorio == EnderecoConsultorio);
        }

        /// <summary>
        /// Método para obter todos os registros de consultório
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public Consultorio ObterTodos(string Nome)
        {
            return SymContext.Consultorios.FirstOrDefault(c => c.NomeConsultorio == Nome);
        }
    }
}
