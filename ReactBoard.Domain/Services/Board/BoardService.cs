using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Board;
using System.Threading.Tasks;
using _Board = ReactBoard.Domain.Entities.Board.Board;

namespace ReactBoard.Domain.Services.Board
{
    public sealed class BoardService : EntityService<_Board, int>, IBoardService
    {
        private readonly IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository) : base(boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<IBoard> GetByUrlNameAsync(string urlName)
        {
            return await _boardRepository.GetByUrlNameAsync(urlName);
        }
    }
}