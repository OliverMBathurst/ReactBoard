using ReactBoard.Domain.Common;
using System.Collections.Generic;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Domain.Entities.Board
{
    public class Board : Entity<int>, IBoard
    {
        public Board() { }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string BoardUrlName { get; set; }

        public bool IsWorkSafe { get; set; }

        public int MaxThreads { get; set; }

        public virtual List<_Thread> Threads { get; set; }
    }
}