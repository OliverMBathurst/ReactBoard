using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.Board
{
    public class BoardAdminMapping : Entity<BoardAdminMappingKey>, IBoardAdminMapping
    {
        public BoardAdminMapping(BoardAdminMappingKey key) : base(key) { }
    }
}