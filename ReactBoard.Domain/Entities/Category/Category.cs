using ReactBoard.Domain.Common;
using System.Collections.Generic;
using _Board = ReactBoard.Domain.Entities.Board.Board;

namespace ReactBoard.Domain.Entities.Category
{
    public class Category : Entity<int>, ICategory
    {
        public string Name { get; set; }

        public virtual List<_Board> Boards { get; set; }
    }
}
