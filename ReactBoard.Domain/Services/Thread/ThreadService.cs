using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Thread;
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

        public async Task DeleteThread(int boardId, long threadId)
        {
            await _threadRepository.DeleteThread(boardId, threadId);
        }

        public async Task<IThread> GetThread(int boardId, long threadId)
        {
            return await _threadRepository.GetThread(boardId, threadId);
        }
    }
}
