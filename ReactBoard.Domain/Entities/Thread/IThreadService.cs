using ReactBoard.Domain.Common;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.Thread
{
    public interface IThreadService : IEntityService<Thread, long>
    {
        Task<IThread> GetThread(int boardId, long threadId);

        Task DeleteThread(int boardId, long threadId);
    }
}
