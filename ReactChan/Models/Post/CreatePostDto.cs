using System;

namespace ReactChan.Models.Post
{
    public sealed class CreatePostDto
    {
        public string Content { get; set; }

        public Guid ThreadId { get; set; }
    }
}
