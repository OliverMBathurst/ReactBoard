using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Post;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Domain.Services.Post
{
    public sealed class PostService : EntityService<_Post, PostKey>, IPostService
    {
        public PostService(IPostRepository repository) : base(repository) { }
    }
}