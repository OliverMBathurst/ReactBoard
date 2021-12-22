using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Board;
using System;

namespace ReactChan.Domain.Services.Board
{
    public class BoardService : EntityService<IBoard, Guid>, IBoardService
    {
        public BoardService(IEntityRepository<IBoard, Guid> boardRepository) : base(boardRepository) { }
    }
}