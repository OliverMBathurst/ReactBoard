using ReactChan.Domain.Entities.Board;
using System;
using System.Linq;

namespace ReactChan.Domain.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public IQueryable<IBoard> GetAll()
        {
            return _boardRepository.GetAll();
        }

        public IQueryable<IBoard> GeyByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}