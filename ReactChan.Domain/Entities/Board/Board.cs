using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Thread;
using System;
using System.Collections.Generic;

namespace ReactChan.Domain.Entities.Board
{
    public class Board : Entity<Guid>, IBoard
    {
        public Board(Guid guid) : base(guid) { }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Suffix { get; set; }

        public bool IsWorkSafe { get; set; }

        public IEnumerable<IThread> Threads { get; set; }
    }
}