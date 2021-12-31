using ReactChan.Domain.Entities.Image;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;
using _Post = ReactChan.Domain.Entities.Post.Post;

namespace ReactChan.Infrastructure.Repositories.Post
{
    public class PostRepository : EntityRepository<_Post, Guid>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context) { }
    }
}
