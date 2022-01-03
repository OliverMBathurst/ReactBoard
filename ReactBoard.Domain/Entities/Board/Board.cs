using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Thread;
using System.Collections.Generic;

namespace ReactBoard.Domain.Entities.Board
{
    public class Board : Entity<BoardKey>, IBoard
    {
        public Board(BoardKey key) : base(key) { }

        public string Name { get; set; }

        public string Description { get; set; }

        public string BoardUrlName { get; set; }

        public bool IsWorkSafe { get; set; }

        public int MaxThreads { get; set; }

        public IEnumerable<IThread> Threads { get; set; }
    }
}