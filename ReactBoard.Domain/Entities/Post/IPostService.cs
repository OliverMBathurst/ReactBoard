using ReactBoard.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.Post
{
    public interface IPostService : IEntityService<Post, long>
    {
        Task<IPost> GetPostAsync(long postId);

        IEnumerable<IPost> GetAllPostsForThread(long threadId);
    }
}