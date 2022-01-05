using _Board = ReactBoard.Domain.Entities.Board.Board;

namespace ReactBoard.Models.Board
{
    public sealed class CreateBoardDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BoardUrlName { get; set; }

        public bool IsWorkSafe { get; set; }

        public int MaxThreads { get; set; } = int.MaxValue;

        public static implicit operator _Board(CreateBoardDto dto) 
        {
            return new _Board
            {
                Name = dto.Name,
                Description = dto.Description,
                BoardUrlName = dto.BoardUrlName,
                IsWorkSafe = dto.IsWorkSafe,
                MaxThreads = dto.MaxThreads
            };
        }
    }
}