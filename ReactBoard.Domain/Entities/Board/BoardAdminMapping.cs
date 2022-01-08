using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Board
{
    public class BoardAdminMapping : Entity<int>, IBoardAdminMapping
    {
        public BoardAdminMapping() { }

        public int BoardId { get; set; }

        public int UserId { get; set; }
    }
}