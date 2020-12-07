using Sym.Medicos.Core.Domain.Contracts;
using Sym.Medicos.Core.Domain.Entities;
using Sym.Medicos.Core.Repository.Context;
using System.Linq;

namespace Sym.Medicos.Core.Repository.Repositories
{
    public class UsuarioRepository : BaseRespository<Usuario>, IUsuarioRepository
    {
        /// <summary>
        /// Método Construtor
        /// </summary>
        public UsuarioRepository(SymContext symContext)
            : base(symContext)
        {

        }

        /// <summary>
        /// Método responsável por trazer um determinar usuário
        /// </summary>
        /// <param name="email">E-mail do usuáruio</param>
        /// <returns></returns>
        public Usuario Obter(string email)
        {
            return SymContext.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        /// <summary>
        /// Método responsável por trazer todos os usuários
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public Usuario ObterTodos(string email, string senha)
        {
            return SymContext.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
