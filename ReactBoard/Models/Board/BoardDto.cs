using ReactBoard.API.Models.Thread;
using System.Collections.Generic;

namespace ReactBoard.API.Models.Board
{
    public sealed class BoardDto 
    {
        public string Name { get; set; }

        public string UrlName { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool IsWorkSafe { get; set; }

        public int MaxThreads { get; set; }

        public IEnumerable<ThreadDto> Threads { get; set; }
    }
}
