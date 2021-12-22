using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Thread;
using System;

namespace ReactChan.Domain.Services.Thread
{
    public class ThreadService : EntityService<IThread, Guid>, IThreadService
    {
        public ThreadService(IEntityRepository<IThread, Guid> repository) : base(repository) { }
    }
}
