namespace ReactBoard.Domain.Interfaces
{
    public interface IEntity<TEntity> where TEntity : struct
    {
        TEntity Id { get; set; }
    }
}
