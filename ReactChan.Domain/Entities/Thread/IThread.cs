using ReactBoard.Domain.Entities.Post;
using ReactBoard.Domain.Interfaces;
using System.Collections.Generic;

namespace ReactBoard.Domain.Entities.Thread
{
    public interface IThread : IEntity<ThreadKey>
    {
        IEnumerable<IPost> Posts { get; set; }

        bool Locked { get; set; }
    }
}
