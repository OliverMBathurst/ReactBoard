using ReactBoard.Domain.Common;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.Thread
{
    public interface IThreadService : IEntityService<Thread, long>
    {
        Task<IThread> GetThreadAsync(long threadId, int boardId);

        Task DeleteThreadAsync(long threadId, int boardId);
    }
}
