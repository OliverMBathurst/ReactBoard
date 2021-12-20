using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Post;
using System;
using System.Collections.Generic;

namespace ReactChan.Domain.Entities.Thread
{
    public class Thread : Entity<Guid>, IThread
    {
        public Thread(Guid id) : base(id) { }

        public Guid BoardId { get; set; }
        
        public IEnumerable<IPost> Posts { get; set; }
    }
}
