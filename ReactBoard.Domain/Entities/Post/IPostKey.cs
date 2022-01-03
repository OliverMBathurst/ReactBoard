namespace ReactBoard.Domain.Entities.Post
{
    public interface IPostKey
    {
        long? PostId { get; }

        long ThreadId { get; }

        int BoardId { get; }
    }
}
