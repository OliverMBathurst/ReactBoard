using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Board;
using System;
using _Board = ReactChan.Domain.Entities.Board.Board;

namespace ReactChan.Domain.Services.Board
{
    public class BoardService : EntityService<_Board, Guid>, IBoardService
    {
        public BoardService(IEntityRepository<_Board, Guid> boardRepository) : base(boardRepository) { }
    }
}