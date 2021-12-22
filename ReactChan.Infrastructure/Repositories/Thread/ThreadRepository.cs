using ReactChan.Domain.Entities.Image;
using ReactChan.Domain.Entities.Thread;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;

namespace ReactChan.Infrastructure.Repositories.Thread
{
    public class ThreadRepository : EntityRepository<IThread, Guid>, IThreadRepository
    {
        public ThreadRepository(ApplicationDbContext context) : base(context) { }
    }
}