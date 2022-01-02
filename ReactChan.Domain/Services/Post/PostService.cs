using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Post;
using _Post = ReactChan.Domain.Entities.Post.Post;

namespace ReactChan.Domain.Services.Post
{
    public class PostService : EntityService<_Post, PostKey>, IPostService
    {
        public PostService(IEntityRepository<_Post, PostKey> repository) : base(repository) { }
    }
}