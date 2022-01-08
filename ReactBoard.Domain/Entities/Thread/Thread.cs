using ReactBoard.Domain.Common;
using System.Collections.Generic;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Domain.Entities.Thread
{
    public class Thread : Entity<long>, IThread
    {
        public Thread() { }

        public int BoardId { get; set; }

        public bool Locked { get; set; }

        public virtual List<_Post> Posts { get; set; }
    }
}
