using ReactChan.Domain.Common;
using System;
using _Post = ReactChan.Domain.Entities.Post.Post;

namespace ReactChan.Domain.Entities.Image
{
    public interface IPostRepository : IEntityRepository<_Post, Guid>
    {
    }
}