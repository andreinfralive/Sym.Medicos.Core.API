using Sym.Medicos.Core.Domain.Entities;

namespace Sym.Medicos.Core.Domain.Contracts
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        /// <summary>
        /// Método para trazer um determinar usuário
        /// </summary>
        /// <param name="email">Email do usuário cadastrado</param>
        Usuario Obter(string email);

        /// <summary>
        /// Método responsável por trazer todos os registros
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        Usuario ObterTodos(string email, string senha);
    }
}
