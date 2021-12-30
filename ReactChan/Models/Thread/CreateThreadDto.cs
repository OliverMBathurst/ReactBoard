using ReactChan.Domain.Entities.Post;
using System;

namespace ReactChan.Models.Thread
{
    public sealed class CreateThreadDto
    {
        public Guid BoardId { get; set; }

        public IPost Post { get; set; }
    }
}
