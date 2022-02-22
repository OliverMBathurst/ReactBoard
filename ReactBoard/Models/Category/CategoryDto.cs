using ReactBoard.API.Models.Board;
using ReactBoard.Domain.Entities.Category;
using System.Collections.Generic;
using System.Linq;

namespace ReactBoard.API.Models.Category
{
    public sealed class CategoryDto 
    {
        public CategoryDto(ICategory category)
        {
            Id = category.Id;
            Name = category.Name;
            Boards = category.Boards.Select(board => new BoardDto(board));
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<BoardDto> Boards { get; set; }
    } 
}
