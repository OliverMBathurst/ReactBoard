using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Thread;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Domain.Entities.Image
{
    public interface IThreadRepository : IEntityRepository<_Thread, ThreadKey>
    {
    }
}