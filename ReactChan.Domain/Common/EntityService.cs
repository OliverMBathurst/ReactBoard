using ReactChan.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactChan.Domain.Common
{
    public abstract class EntityService<TEntity, TId> : IEntityService<TEntity, TId> 
        where TEntity : class, IEntity<TId>
        where TId : struct, IEquatable<TId>
    {
        private readonly IEntityRepository<TEntity, TId> _repository;

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
    }
}