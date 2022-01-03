namespace ReactBoard.Domain.Entities.Thread
{
    public interface IThreadKey
    {
        long? ThreadId { get; }

        int BoardId { get; }
    }
}
