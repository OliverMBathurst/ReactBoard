using ReactChan.Domain.Entities.Image;
using System;
using _Post = ReactChan.Domain.Entities.Post.Post;

namespace ReactChan.Models.Post
{
    public sealed class CreatePostDto
    {
        public string Text { get; set; }

        public Guid ThreadId { get; set; }

        public Guid BoardId { get; set; }

        public IImage Image { get; set; }

        public static implicit operator _Post(CreatePostDto postDto)
        {
            return new _Post(Guid.NewGuid())
            {
                Text = postDto.Text,
                ThreadId = postDto.ThreadId,
                BoardId = postDto.BoardId,
                Image = postDto.Image
            };
        }
    }
}
