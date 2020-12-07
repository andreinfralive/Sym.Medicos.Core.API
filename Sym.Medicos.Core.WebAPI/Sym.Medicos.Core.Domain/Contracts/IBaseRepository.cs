using System;
using System.Collections.Generic;

namespace Sym.Medicos.Core.Domain.Contracts
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Metódo genérico para adicionar um registro a uma entidade
        /// </summary>
        /// <param name="entity"></param>
        void Adicionar(TEntity entity);

        /// <summary>
        /// Método genérico de buscar um registro passando um Id para uma entidade
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TEntity ObterPorId(int Id);

        /// <summary>
        /// Método genérico de obter todos os registros da uma entidade
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> ObterTodos();

        /// <summary>
        /// Método genérico de fazer a atualização de um entidade
        /// </summary>
        /// <param name="entity"></param>
        void Atualizar(TEntity entity);

        /// <summary>
        /// Método genérico de fazer a deleção de um registro de uma entidade
        /// </summary>
        /// <param name="entity"></param>
        void Remover(TEntity entity);
    }
}
