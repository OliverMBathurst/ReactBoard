using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Domain.Entities.Thread;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Infrastructure.Repositories.Thread
{
    public sealed class ThreadRepository : EntityRepository<_Thread, long>, IThreadRepository
    {
        private readonly AppSettings _appSettings;

        public ThreadRepository(DatabaseContext context, IOptions<AppSettings> options) : base(context) 
        {
            _appSettings = options.Value;
        }

        public async Task<IThread> GetThreadAsync(long threadId)
        {
            return await _context.Set<_Thread>()
                .FirstOrDefaultAsync(x => x.Id.Equals(threadId));
        }

        public async Task DeleteThreadAsync(long threadId) 
        {
            var thread = await _context.Set<_Thread>()
                .FirstOrDefaultAsync(x => x.Id.Equals(threadId));

            if (thread != null)
            {
                _context.Remove(thread);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IPost>> GetNewPosts(long threadId, DateTime latest)
        {
            var thread = await _context.Set<_Thread>()
                .Include(x => x.Posts)
                .FirstOrDefaultAsync(x => x.Id.Equals(threadId));

            if (thread == null)
                return new List<IPost>();

            return thread.Posts.Where(x => x.Time > latest).ToList();
        }

        public async Task<IPaginationResult<IThread>> GetPaginatedThreadsForBoard(int boardId, int pageNumber)
        {
            var threadsForBoard = _context.Set<_Thread>().Where(x => x.BoardId.Equals(boardId));
            var totalPageCount = (int)Math.Ceiling(await threadsForBoard.LongCountAsync() / (double) _appSettings.ThreadsPerPage);
            var threads = threadsForBoard.OrderBy(x => x.Posts.Count)
                .Skip((pageNumber - 1) * _appSettings.ThreadsPerPage)
                .Take(_appSettings.ThreadsPerPage)
                .ToList();

            return new PaginationResult<IThread>
            {
                CurrentPage = pageNumber,
                TotalPages = totalPageCount,
                Entities = threads
            };
        }
    }
}