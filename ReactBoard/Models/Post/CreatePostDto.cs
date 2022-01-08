using _Post = ReactBoard.Domain.Entities.Post.Post;

namespace ReactBoard.Models.Post
{
    public sealed class CreatePostDto
    {
        public string Text { get; set; }

        public long ThreadId { get; set; }

        public int BoardId { get; set; }

        public long? ImageId { get; set; }

        public static implicit operator _Post(CreatePostDto postDto)
        {
            return new _Post
            {
                ThreadId = postDto.ThreadId,
                BoardId = postDto.BoardId,
                Text = postDto.Text,
                ImageId = postDto.ImageId
            };
        }
    }
}
