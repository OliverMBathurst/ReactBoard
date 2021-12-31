using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Post;
using System;
using _Post = ReactChan.Domain.Entities.Post.Post;

namespace ReactChan.Domain.Services.Post
{
    public class PostService : EntityService<_Post, Guid>, IPostService
    {
        public PostService(IEntityRepository<_Post, Guid> repository) : base(repository) { }
    }
}