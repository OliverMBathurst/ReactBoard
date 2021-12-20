using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.Board;
using System;

namespace ReactChan.Domain.Services
{
    public class BoardService : EntityService<IBoard, Guid>, IBoardService
    {
        private readonly IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository) : base(boardRepository)
        {
            _boardRepository = boardRepository;
        }
    }
}