using ReactBoard.Domain.Common;
using System;
using System.Collections.Generic;

namespace ReactBoard.Domain.Entities.Post
{
    public interface IPost : IEntity<long>
    {
        long ThreadId { get; set; }

        int BoardId { get; set; }

        long? ImageId { get; set; }

        DateTime Time { get; set; }

        string Text { get; set; }

        List<Post> Replies { get; set; }
    }
}
