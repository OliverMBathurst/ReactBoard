using ReactChan.Domain.Entities.Post;

namespace ReactChan.Models.Thread
{
    public sealed class CreateThreadDto
    {
        public int BoardId { get; set; }

        public IPost Post { get; set; }
    }
}
