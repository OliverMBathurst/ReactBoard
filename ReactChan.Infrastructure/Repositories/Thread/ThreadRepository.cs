using ReactChan.Domain.Entities.Image;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;
using _Thread = ReactChan.Domain.Entities.Thread.Thread;

namespace ReactChan.Infrastructure.Repositories.Thread
{
    public class ThreadRepository : EntityRepository<_Thread, Guid>, IThreadRepository
    {
        public ThreadRepository(ApplicationDbContext context) : base(context) { }
    }
}