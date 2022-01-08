using Microsoft.EntityFrameworkCore;
using ReactBoard.Domain.Entities.Thread;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using System.Threading.Tasks;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Infrastructure.Repositories.Thread
{
    public sealed class ThreadRepository : EntityRepository<_Thread, long>, IThreadRepository
    {
        public ThreadRepository(DatabaseContext context) : base(context) { }

        public async Task<IThread> GetThreadAsync(long threadId, int boardId)
        {
            return await _context.Set<_Thread>()
                .FirstOrDefaultAsync(x => x.BoardId.Equals(boardId) && x.Id.Equals(threadId));
        }

        public async Task DeleteThreadAsync(long threadId, int boardId) 
        {
            var thread = await _context.Set<_Thread>()
                .FirstOrDefaultAsync(x => x.BoardId.Equals(boardId) && x.Id.Equals(threadId));

            if (thread != null)
            {
                _context.Remove(thread);
                await _context.SaveChangesAsync();
            }
        }
    }
}