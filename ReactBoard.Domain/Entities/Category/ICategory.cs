using ReactBoard.Domain.Common;
using System.Collections.Generic;
using _Board = ReactBoard.Domain.Entities.Board.Board;

namespace ReactBoard.Domain.Entities.Category
{
    public interface ICategory : IEntity<int>
    {
        string Name { get; set; }

        List<_Board> Boards { get; set; }
    }
}