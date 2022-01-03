using ReactBoard.Domain.Entities.Image;
using ReactBoard.Domain.Entities.Thread;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Infrastructure.Repositories.Thread
{
    public sealed class ThreadRepository : EntityRepository<_Thread, ThreadKey>, IThreadRepository
    {
        public ThreadRepository(ApplicationDbContext context) : base(context) { }
    }
}