using ReactBoard.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Domain.Entities.Post
{
    public interface IPostRepository : IEntityRepository<_Post, long>
    {
        Task<IPost> GetPostAsync(long postId);

        IEnumerable<IPost> GetAllPostsForThread(long threadId);
    }
}