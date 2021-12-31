using ReactChan.Domain.Common;
using System;
using _Thread = ReactChan.Domain.Entities.Thread.Thread;

namespace ReactChan.Domain.Entities.Image
{
    public interface IThreadRepository : IEntityRepository<_Thread, Guid>
    {
    }
}