using System;

namespace ReactBoard.Models.Thread
{
    public sealed class ThreadUpdateRequestDto
    {
        public long ThreadId { get; set; }

        public DateTime Latest { get; set; }
    }
}
