using ReactBoard.API.Models.Post;
using ReactBoard.Domain.Entities.Thread;
using System.Collections.Generic;
using System.Linq;

namespace ReactBoard.API.Models.Thread
{
    public sealed class ThreadDto
    {
        public ThreadDto(IThread thread)
        { 
            Id = thread.Id;
            BoardId = thread.BoardId;
            Locked = thread.Locked;
            Posts = thread.Posts.Select(post => new PostDto(post));
        }

        public long Id { get; set; }

        public int BoardId { get; set; }

        public bool Locked { get; set; }

        public IEnumerable<PostDto> Posts { get; set; }
    }
}
