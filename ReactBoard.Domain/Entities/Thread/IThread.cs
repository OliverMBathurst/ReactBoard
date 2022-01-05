using ReactBoard.Domain.Common;
using System.Collections.Generic;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Domain.Entities.Thread
{
    public interface IThread : IEntity<long>
    {
        int BoardId { get; set; }

        List<_Post> Posts { get; set; }

        bool Locked { get; set; }
    }
}
