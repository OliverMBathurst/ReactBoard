using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Image;
using System;
using System.Collections.Generic;

namespace ReactChan.Domain.Entities.Post
{
    public class Post : Entity<Guid>, IPost
    {
        public Post(Guid postId): base(postId) { }

        public Guid ThreadId { get; set; }

        public Guid BoardId { get; set; }

        public DateTime Time { get; set; }

        public string Text { get; set; }

        public IImage Image { get; set; }

        public IEnumerable<IPost> Replies { get; set; }
    }
}
