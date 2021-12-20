using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Thread;
using System;

namespace ReactChan.Domain.Entities.Image
{
    public interface IThreadRepository : IEntityRepository<IThread, Guid>
    {
    }
}