using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Post;
using _Post = ReactChan.Domain.Entities.Post.Post;

namespace ReactChan.Domain.Entities.Image
{
    public interface IPostRepository : IEntityRepository<_Post, PostKey>
    {
    }
}