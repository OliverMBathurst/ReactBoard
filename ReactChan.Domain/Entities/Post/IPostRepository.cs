using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Post;
using System;

namespace ReactChan.Domain.Entities.Image
{
    public interface IPostRepository : IEntityRepository<IPost, Guid>
    {
    }
}