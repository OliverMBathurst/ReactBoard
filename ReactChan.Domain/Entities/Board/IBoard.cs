﻿using ReactBoard.Domain.Entities.Thread;
using ReactBoard.Domain.Interfaces;
using System.Collections.Generic;

namespace ReactBoard.Domain.Entities.Board
{
    public interface IBoard : IEntity<BoardKey>
    {
        string Name { get; set; }

        string BoardUrlName { get; set; }

        string Description { get; set; }

        bool IsWorkSafe { get; set; }

        int MaxThreads { get; set; }

        IEnumerable<IThread> Threads { get; set; }
    }
}
