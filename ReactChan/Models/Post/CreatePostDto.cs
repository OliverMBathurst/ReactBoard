using System;

namespace ReactChan.Models.Post
{
    public sealed class CreatePostDto
    {
        public string Text { get; set; }

        public Guid ThreadId { get; set; }
    }
}
