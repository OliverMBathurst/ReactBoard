using System.Collections.Generic;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.API.Models.Thread
{
    public sealed class PaginatedThreadResultDto
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public List<_Thread> Threads { get; set; }
    }
}
