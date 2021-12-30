using Microsoft.EntityFrameworkCore;
using ReactChan.Domain.Common;
using ReactChan.Domain.Interfaces;
using ReactChan.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactChan.Infrastructure.Common
{
    public abstract class EntityRepository<TEntity, TId> : IEntityRepository<TEntity, TId> 
        where TEntity : class, IEntity<TId>
        where TId : struct, IEquatable<TId>
    {
        private readonly ApplicationDbContext _context;

        protected EntityRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual Task<TEntity> GetByIdAsync(TId id)
        {
            return _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual IEnumerable<TEntity> Fetch(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public virtual async Task SaveOrUpdateAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}