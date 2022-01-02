using ReactChan.Domain.Common;

namespace ReactChan.Domain.Entities.Board
{
    public class BoardAdminMapping : Entity<BoardAdminMappingKey>, IBoardAdminMapping
    {
        public BoardAdminMapping(BoardAdminMappingKey key) : base(key) { }
    }
}