using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Domain.Entities.Thread;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Domain.Services.Thread
{
    public sealed class ThreadService : EntityService<_Thread, long>, IThreadService
    {
        private readonly IThreadRepository _threadRepository;

        public ThreadService(IThreadRepository threadRepository) : base(threadRepository) 
        {
            _threadRepository = threadRepository;
        }

        public async Task<IPaginationResult<IThread>> GetPaginatedThreadsForBoard(int boardId, int pageNumber)
        {
            return await _threadRepository.GetPaginatedThreadsForBoard(boardId, pageNumber);
        }

        public async Task DeleteThreadAsync(long threadId)
        {
            await _threadRepository.DeleteThreadAsync(threadId);
        }

        public async Task<IThread> GetThreadAsync(long threadId)
        {
            return await _threadRepository.GetThreadAsync(threadId);
        }

        public async Task<IEnumerable<IPost>> GetNewPosts(long threadId, DateTime latest)
        {
            return await _threadRepository.GetNewPosts(threadId, latest);
        }
    }
}
