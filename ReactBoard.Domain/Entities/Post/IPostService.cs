using ReactBoard.Domain.Common;
using System.Collections.Generic;

namespace ReactBoard.Domain.Entities.Post
{
    public interface IPostService : IEntityService<Post, long>
    {
        IEnumerable<IPost> GetAllPostsForThread(int boardId, int threadId);
    }
}
