using ReactBoard.Domain.Common;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.Board
{
    public interface IBoardService : IEntityService<Board, int>
    {
        Task<IBoard> GetByUrlNameAsync(string urlName);
    }
}
