using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Image;
using System;
using System.Collections.Generic;

namespace ReactBoard.Domain.Entities.Post
{
    public class Post : Entity<PostKey>, IPost
    {
        public Post(PostKey key): base(key) { }

        public DateTime Time { get; set; } = DateTime.Now;

        public string Text { get; set; }

        public IImage Image { get; set; }

        public IEnumerable<IPost> Replies { get; set; }
    }
}
