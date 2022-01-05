using ReactBoard.Domain.Common;
using System;
using System.Collections.Generic;

namespace ReactBoard.Domain.Entities.Post
{
    public class Post : Entity<long>, IPost
    {
        public Post() { }

        public long ThreadId { get; set; }

        public int BoardId { get; set; }

        public long? ImageId { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;

        public string Text { get; set; }

        public List<Post> Replies { get; set; }
    }
}
