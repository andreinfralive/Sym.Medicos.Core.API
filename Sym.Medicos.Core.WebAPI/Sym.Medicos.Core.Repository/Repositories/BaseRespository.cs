using Sym.Medicos.Core.Domain.Contracts;
using Sym.Medicos.Core.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Sym.Medicos.Core.Repository.Repositories
{
    public class BaseRespository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Instanciando o SymContext
        /// </summary>
        protected readonly SymContext SymContext;

        /// <summary>
        /// Construtor
        /// </summary>
        public BaseRespository(SymContext symContext)
        {
            SymContext = symContext;
        }

        /// <summary>
        /// Adicionar novos Registros
        /// </summary>
        /// <param name="entity"></param>
        public void Adicionar(TEntity entity)
        {
            SymContext.Set<TEntity>().Add(entity);
            SymContext.SaveChanges();
        }

        /// <summary>
        /// Atualizar os dados na base de dados
        /// </summary>
        /// <param name="entity"></param>
        public void Atualizar(TEntity entity)
        {
            SymContext.Set<TEntity>().Update(entity);
            SymContext.SaveChanges();
        }

        /// <summary>
        /// Retornar registro por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TEntity ObterPorId(int Id)
        {
            return SymContext.Set<TEntity>().Find(Id);
        }

        /// <summary>
        /// Obter Todos os registros
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> ObterTodos()
        {
            return SymContext.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Remover registro da tabela
        /// </summary>
        /// <param name="entity"></param>
        public void Remover(TEntity entity)
        {
            SymContext.Remove(entity);
            SymContext.SaveChanges();
        }

        /// <summary>
        /// Descargar o BaseRepository da Memória
        /// </summary>
        public void Dispose()
        {
            SymContext.Dispose();
        }
    }
}
