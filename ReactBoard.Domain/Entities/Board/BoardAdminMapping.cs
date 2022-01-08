using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Board
{
    public class BoardAdminMapping : Entity<int>, IBoardAdminMapping
    {
        public BoardAdminMapping() { }

        public int UserId { get; set; }
    }
}