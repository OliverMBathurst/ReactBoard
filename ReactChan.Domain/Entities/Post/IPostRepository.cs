using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Post;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Domain.Entities.Image
{
    public interface IPostRepository : IEntityRepository<_Post, PostKey>
    {
    }
}