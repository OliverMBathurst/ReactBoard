using ReactChan.Domain.Common;
using System;

namespace ReactChan.Domain.Entities.Board
{
    public interface IBoardRepository : IEntityRepository<Board, BoardKey>
    {
    }
}
