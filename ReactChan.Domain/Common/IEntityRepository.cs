using ReactBoard.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Common
{
    public interface IEntityRepository<TEntity, TId> 
        where TEntity : class, IEntity<TId>
        where TId : struct, IEquatable<TId>
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(TId id);

        IEnumerable<TEntity> Fetch(Func<TEntity, bool> predicate);

        Task SaveOrUpdateAsync(TEntity entity);

        Task DeleteAsync(TId id);
    }
}
