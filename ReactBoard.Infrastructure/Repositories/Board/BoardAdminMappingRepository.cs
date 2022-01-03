using ReactBoard.Domain.Entities.Board;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;

namespace ReactBoard.Infrastructure.Repositories.Board
{
    public sealed class BoardAdminMappingRepository : EntityRepository<BoardAdminMapping, BoardAdminMappingKey>, IBoardAdminMappingRepository
    {
        public BoardAdminMappingRepository(ApplicationDbContext context) : base(context) { }
    }
}
