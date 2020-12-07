using Sym.Medicos.Core.Domain.Entities;

namespace Sym.Medicos.Core.Domain.Contracts
{
    public interface IConsultorioRepository : IBaseRepository<Consultorio>
    {
        /// <summary>
        /// Método responsável por obter um determinado registro
        /// </summary>
        /// <param name="Nome">Nome do Consultório</param>
        /// <param name="Endereco">Endereço do Consultório</param>
        /// <returns></returns>
        Consultorio Obter(string Nome, string Endereco);

        /// <summary>
        /// Método responsável por obter todos os registros
        /// </summary>
        /// <param name="Nome">Nome</param>
        /// <returns></returns>
        Consultorio ObterTodos(string Nome);
    }
}
