using ReactChan.Domain.Interfaces;
using System.Linq;

namespace ReactChan.Domain.Common
{
    public interface IEntityService<TEntity, TId> 
        where TEntity : IEntity<TId>
        where TId : struct
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GeyByIdAsync(TId id);
    }
}
