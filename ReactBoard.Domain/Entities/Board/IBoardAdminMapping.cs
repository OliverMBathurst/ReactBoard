using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Board
{
    public interface IBoardAdminMapping : IEntity<int>
    {
        int BoardId { get; set; }

        int UserId { get; set; }
    }
}
