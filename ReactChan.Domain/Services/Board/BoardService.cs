using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Board;
using _Board = ReactChan.Domain.Entities.Board.Board;

namespace ReactChan.Domain.Services.Board
{
    public class BoardService : EntityService<_Board, BoardKey>, IBoardService
    {
        public BoardService(IEntityRepository<_Board, BoardKey> boardRepository) : base(boardRepository) { }
    }
}