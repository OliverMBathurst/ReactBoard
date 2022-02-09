using ReactBoard.Domain.Common;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.Board
{
    public interface IBoardRepository : IEntityRepository<Board, int>
    {
        Task<IBoard> GetByUrlNameAsync(string urlName);
    }
}
