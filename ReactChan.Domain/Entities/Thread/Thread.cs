using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Post;
using System;
using System.Collections.Generic;

namespace ReactBoard.Domain.Entities.Thread
{
    public class Thread : Entity<ThreadKey>, IThread
    {
        public Thread(ThreadKey key) : base(key) { }

        public Guid BoardId { get; set; }
        
        public IEnumerable<IPost> Posts { get; set; }

        public bool Locked { get; set; }
    }
}
