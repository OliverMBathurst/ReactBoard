using ReactBoard.Domain.Common;
using System.Collections.Generic;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Domain.Entities.Post
{
    public interface IPostRepository : IEntityRepository<_Post, long>
    {
        IEnumerable<IPost> GetAllPostsForThread(int boardId, int threadId);
    }
}