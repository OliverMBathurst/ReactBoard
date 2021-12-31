using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Thread;
using System;
using _Thread = ReactChan.Domain.Entities.Thread.Thread;

namespace ReactChan.Domain.Services.Thread
{
    public class ThreadService : EntityService<_Thread, Guid>, IThreadService
    {
        public ThreadService(IEntityRepository<_Thread, Guid> repository) : base(repository) { }
    }
}
