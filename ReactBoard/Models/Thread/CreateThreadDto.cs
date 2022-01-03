using ReactBoard.Domain.Entities.Post;

namespace ReactBoard.Models.Thread
{
    public sealed class CreateThreadDto
    {
        public int BoardId { get; set; }

        public IPost Post { get; set; }
    }
}
