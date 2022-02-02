using System.Collections.Generic;
using _Post = ReactBoard.Domain.Entities.Post.Post;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Models.Thread
{
    public sealed class CreateThreadDto
    {
        public int BoardId { get; set; }

        public _Post Post { get; set; }

        public static implicit operator _Thread(CreateThreadDto dto)
        {
            return new _Thread {
                BoardId = dto.BoardId,
                Posts = new List<_Post> { 
                    dto.Post
                }
            };
        }
    }
}
