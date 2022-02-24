using ReactBoard.Domain.Entities.Post;
using ReactBoard.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.API.Models.Post
{
    public sealed class PostDto
    {
        public PostDto() { }

        public PostDto(IPost post)
        {
            Id = post.Id;
            Time = post.Time;
            Text = post.Text;
            ImageId = post.ImageId;
            Replies = post.Replies.Select(post =>
            {
                PostDto dto = post;
                return dto;
            }).ToList();
        }

        public long Id { get; set; }

        [field: NonSerialized]
        public long? ImageId { get; set; }

        public ApiImageDto Image { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;

        public string Text { get; set; }

        public List<PostDto> Replies { get; set; }

        public static implicit operator PostDto(_Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                Time = post.Time,
                Text = post.Text,
                ImageId = post.ImageId,
                Replies = post.Replies.Select(x =>
                {
                    PostDto dto = x;
                    return dto;
                }).ToList()
            };
        }

        public void Deconstruct(
            out long id,
            out long? imageId,
            out ApiImageDto imageDto,
            out DateTime time,
            out string text)
        {
            id = Id;
            imageId = ImageId;
            imageDto = Image;
            time = Time;
            text = Text;
        }
    }
}
