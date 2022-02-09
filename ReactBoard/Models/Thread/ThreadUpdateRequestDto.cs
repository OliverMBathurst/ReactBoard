using System;

namespace ReactBoard.API.Models.Thread
{
    public sealed class ThreadUpdateRequestDto
    {
        public long ThreadId { get; set; }

        public DateTime Latest { get; set; }
    }
}
