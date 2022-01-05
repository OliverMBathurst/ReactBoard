using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Board
{
    public interface IBoardAdminMapping : IEntity<int>
    {
        int UserId { get; set; }

        int BoardId { get; set; }
    }
}
