using ReactChan.Domain.Common;
using System;

namespace ReactChan.Domain.Entities.Board
{
    public interface IBoardAdminMappingRepository : IEntityRepository<BoardAdminMapping, BoardAdminMappingKey>
    {
    }
}
