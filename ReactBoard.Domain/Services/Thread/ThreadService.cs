using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Thread;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Domain.Services.Thread
{
    public sealed class ThreadService : EntityService<_Thread, ThreadKey>, IThreadService
    {
        public ThreadService(IEntityRepository<_Thread, ThreadKey> repository) : base(repository) { }
    }
}
