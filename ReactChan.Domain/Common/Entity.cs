using ReactChan.Domain.Interfaces;

namespace ReactChan.Domain.Common
{
    public class Entity<TEntity> : IEntity<TEntity> where TEntity : struct
    {
        public Entity(TEntity id) => Id = id;

        public TEntity Id { get; set; }
    }
}
