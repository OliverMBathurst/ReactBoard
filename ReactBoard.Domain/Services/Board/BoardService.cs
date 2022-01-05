using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Board;
using _Board = ReactBoard.Domain.Entities.Board.Board;

namespace ReactBoard.Domain.Services.Board
{
    public sealed class BoardService : EntityService<_Board, int>, IBoardService
    {
        public BoardService(IBoardRepository repository) : base(repository) { }
    }
}