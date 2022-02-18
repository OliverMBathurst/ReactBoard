using ReactBoard.API.Models.Board;
using System.Collections.Generic;

namespace ReactBoard.API.Models.Category
{
    public sealed class CategoryDto 
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<BoardDto> Boards { get; set; }
    } 
}
