using ReactChan.Domain.Entities.Image;
using ReactChan.Domain.Entities.Post;
using System;
using _Post = ReactChan.Domain.Entities.Post.Post;

namespace ReactChan.Models.Post
{
    public sealed class CreatePostDto
    {
        public string Text { get; set; }

        public long ThreadId { get; set; }

        public int BoardId { get; set; }

        public IImage Image { get; set; }

        public static implicit operator _Post(CreatePostDto postDto)
        {
            return new _Post(new PostKey(null, postDto.ThreadId, postDto.BoardId))
            {
                Text = postDto.Text,
                Image = postDto.Image
            };
        }
    }
}
