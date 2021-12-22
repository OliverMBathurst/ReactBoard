using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Post;
using System;

namespace ReactChan.Domain.Services.Post
{
    public class PostService : EntityService<IPost, Guid>, IPostService
    {
        public PostService(IEntityRepository<IPost, Guid> repository) : base(repository) { }
    }
}