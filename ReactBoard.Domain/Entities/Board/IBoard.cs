using ReactBoard.Domain.Common;
using System.Collections.Generic;
using _Thread = ReactBoard.Domain.Entities.Thread.Thread;

namespace ReactBoard.Domain.Entities.Board
{
    public interface IBoard : IEntity<int>
    {
        string Name { get; set; }

        string UrlName { get; set; }

        string Description { get; set; }

        int CategoryId { get; set; }

        bool IsWorkSafe { get; set; }

        int MaxThreads { get; set; }

        List<_Thread> Threads { get; set; }
    }
}
