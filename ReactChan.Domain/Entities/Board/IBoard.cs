using ReactChan.Domain.Entities.Thread;
using ReactChan.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ReactChan.Domain.Entities.Board
{
    public interface IBoard : IEntity<Guid>
    {
        Guid BoardId { get; set; }

        string Name { get; set; }

        IEnumerable<IThread> Threads { get; set; }
    }
}
