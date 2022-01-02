using ReactChan.Domain.Entities.Board;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;

namespace ReactChan.Infrastructure.Repositories.Board
{
    public class BoardAdminMappingRepository : EntityRepository<BoardAdminMapping, BoardAdminMappingKey>, IBoardAdminMappingRepository
    {
        public BoardAdminMappingRepository(ApplicationDbContext context) : base(context) { }
    }
}
