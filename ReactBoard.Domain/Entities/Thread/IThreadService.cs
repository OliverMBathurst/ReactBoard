using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.Thread
{
    public interface IThreadService : IEntityService<Thread, long>
    {
        Task<IThread> GetThreadAsync(long threadId);

        Task DeleteThreadAsync(long threadId);

        Task<IPaginationResult<IThread>> GetPaginatedThreadsForBoard(int boardId, int pageNumber);

        Task<IEnumerable<IPost>> GetNewPosts(long threadId, DateTime latest);
    }
}
