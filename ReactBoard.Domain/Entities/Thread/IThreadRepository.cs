using ReactBoard.Domain.Common;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Domain.Entities.Thread
{
    public interface IThreadRepository : IEntityRepository<_Thread, ThreadKey>
    {
    }
}