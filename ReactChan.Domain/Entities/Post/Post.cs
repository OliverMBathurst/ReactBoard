using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Image;
using System;
using System.Collections.Generic;

namespace ReactChan.Domain.Entities.Post
{
    public class Post : Entity<int>, IPost
    {
        public Post(int postId): base(postId) { }

        public int ThreadId { get; set; }

        public int BoardId { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;

        public string Text { get; set; }

        public IImage Image { get; set; }

        public IEnumerable<IPost> Replies { get; set; }
    }
}
