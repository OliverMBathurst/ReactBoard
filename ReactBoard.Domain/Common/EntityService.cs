using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Common
{
    public abstract class EntityService<TEntity, TId> : IEntityService<TEntity, TId> 
        where TEntity : class, IEntity<TId>
    {
        protected readonly IEntityRepository<TEntity, TId> _repository;

        protected EntityService(IEntityRepository<TEntity, TId> repository)
        {
            _repository = repository;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual Task<TEntity> GetByIdAsync(TId id)
        {
            return _repository.GetByIdAsync(id);
        }

        public virtual IEnumerable<TEntity> Fetch(Func<TEntity, bool> predicate)
        {
            return _repository.Fetch(predicate);
        }

        public virtual async Task SaveOrUpdateAsync(TEntity entity)
        {
            await _repository.SaveOrUpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(TId id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}