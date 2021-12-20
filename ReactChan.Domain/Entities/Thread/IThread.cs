using ReactChan.Domain.Entities.Post;
using ReactChan.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ReactChan.Domain.Entities.Thread
{
    public interface IThread : IEntity<Guid>
    {
        Guid BoardId { get; set; }

        IEnumerable<IPost> Posts { get; set; }
    }
}
