using Microsoft.EntityFrameworkCore;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Infrastructure.Repositories.Post
{
    public sealed class PostRepository : EntityRepository<_Post, long>, IPostRepository
    {
        public PostRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<IPost> GetAllPostsForThread(long threadId)
        {
            return _context.Set<_Post>()
                .Where(x => x.ThreadId.Equals(threadId))
                .OrderByDescending(x => x.Time);
        }

        public async Task<IPost> GetPostAsync(long postId)
        {
            return await _context.Set<_Post>()
                .FirstOrDefaultAsync(x => x.Id.Equals(postId));
        }
    }
}
