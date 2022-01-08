using ReactBoard.Domain.Common;
using System.Threading.Tasks;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Domain.Entities.Thread
{
    public interface IThreadRepository : IEntityRepository<_Thread, long>
    {
        Task<IThread> GetThreadAsync(long threadId, int boardId);

        Task DeleteThreadAsync(long threadId, int boardId);
    }
}