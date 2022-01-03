using ReactBoard.Domain.Interfaces;

namespace ReactBoard.Domain.Common
{
    public abstract class Entity<TEntity> : IEntity<TEntity>
        where TEntity : struct
    {
        protected Entity(TEntity id) => Id = id;

        public virtual TEntity Id { get; set; }
    }
}
