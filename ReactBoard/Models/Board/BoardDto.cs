using ReactBoard.API.Models.Thread;
using ReactBoard.Domain.Entities.Board;
using System.Collections.Generic;
using System.Linq;

namespace ReactBoard.API.Models.Board
{
    public sealed class BoardDto 
    {
        public BoardDto(IBoard board)
        {
            Name = board.Name;
            UrlName = board.UrlName;
            Description = board.Description;
            CategoryId = board.CategoryId;
            IsWorkSafe = board.IsWorkSafe;
            MaxThreads = board.MaxThreads;
            Threads = board.Threads.Select(thread => new ThreadDto(thread));
        }

        public string Name { get; set; }

        public string UrlName { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool IsWorkSafe { get; set; }

        public int MaxThreads { get; set; }

        public IEnumerable<ThreadDto> Threads { get; set; }
    }
}
