using ReactBoard.Domain.Entities.Image;
using ReactBoard.Domain.Entities.Post;
using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Models.Post
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
