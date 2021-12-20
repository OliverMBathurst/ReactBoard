using ReactChan.Domain.Interfaces;
using System.Linq;

namespace ReactChan.Domain.Common
{
    public interface IEntityRepository<TEntity, TId> 
        where TEntity : IEntity<TId>
        where TId : struct
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetByIdAsync(TId id);
    }
}
