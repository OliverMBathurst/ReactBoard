using ReactChan.Domain.Entities.Image;
using ReactChan.Domain.Entities.Post;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;

namespace ReactChan.Infrastructure.Repositories.Post
{
    public class PostRepository : EntityRepository<IPost, Guid>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context) { }
    }
}
