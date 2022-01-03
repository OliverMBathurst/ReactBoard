using ReactBoard.Domain.Common;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Domain.Entities.Post
{
    public interface IPostRepository : IEntityRepository<_Post, PostKey>
    {
    }
}