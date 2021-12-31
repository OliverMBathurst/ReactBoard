using ReactChan.Domain.Entities.Thread;
using ReactChan.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ReactChan.Domain.Entities.Board
{
    public interface IBoard : IEntity<Guid>
    {
        string Name { get; set; }

        string BoardUrlName { get; set; }

        string Description { get; set; }

        bool IsWorkSafe { get; set; }

        int MaxThreads { get; set; }

        IEnumerable<IThread> Threads { get; set; }
    }
}
