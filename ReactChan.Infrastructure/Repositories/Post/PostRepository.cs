using ReactBoard.Domain.Entities.Image;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Infrastructure.Repositories.Post
{
    public class PostRepository : EntityRepository<_Post, PostKey>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context) { }
    }
}
