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

        public async Task DeleteThreadAsync(long threadId, int boardId)
        {
            await _threadRepository.DeleteThreadAsync(threadId, boardId);
        }

        public async Task<IThread> GetThreadAsync(long threadId, int boardId)
        {
            return await _threadRepository.GetThreadAsync(threadId, boardId);
        }
    }
}
