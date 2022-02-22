using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Domain.Entities.Thread
{
    public interface IThreadRepository : IEntityRepository<_Thread, long>
    {
        Task<IThread> GetThreadAsync(long threadId);

        Task DeleteThreadAsync(long threadId);

        Task<IPaginationResult<IThread>> GetPaginatedThreadsForBoard(int boardId, int pageNumber);

        Task<IEnumerable<IPost>> GetNewPosts(long threadId, DateTime latest);

        IEnumerable<IThread> GetAllBoardThreads(int boardId);

        Task<IThread> GetTopThreadByBoardIdAsync(int boardId);
    }
}