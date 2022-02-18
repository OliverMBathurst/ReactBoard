using ReactBoard.API.Models.Post;
using System.Collections.Generic;

namespace ReactBoard.API.Models.Thread
{
    public sealed class ThreadDto
    {
        public long Id { get; set; }

        public int BoardId { get; set; }

        public IEnumerable<PostDto> Posts { get; set; }

        public bool Locked { get; set; }
    }
}
