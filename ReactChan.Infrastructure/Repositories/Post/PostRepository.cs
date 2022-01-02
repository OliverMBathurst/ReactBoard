using ReactChan.Domain.Entities.Image;
using ReactChan.Domain.Entities.Post;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using _Post = ReactChan.Domain.Entities.Post.Post;

namespace ReactChan.Infrastructure.Repositories.Post
{
    public class PostRepository : EntityRepository<_Post, PostKey>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context) { }
    }
}
