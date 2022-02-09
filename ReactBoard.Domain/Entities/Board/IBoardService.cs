using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.Thread;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.Board
{
    public interface IBoardService : IEntityService<Board, int>
    {
        Task<IBoard> GetByUrlNameAsync(string urlName);
    }
}
