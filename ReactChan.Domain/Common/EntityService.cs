using ReactChan.Domain.Interfaces;
using System.Linq;

namespace ReactChan.Domain.Common
{
    public abstract class EntityService<TEntity, TId> : IEntityService<TEntity, TId> 
        where TEntity : IEntity<TId>
        where TId : struct
    {
        private readonly IEntityRepository<TEntity, TId> _repository;

        protected EntityService(IEntityRepository<TEntity, TId> repository)
        {
            _repository = repository;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<TEntity> GetByIdAsync(TId id)
        {
            return _repository.GetByIdAsync(id);
        }
    }
}
