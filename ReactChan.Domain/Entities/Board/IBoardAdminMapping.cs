using ReactChan.Domain.Interfaces;
using System;

namespace ReactChan.Domain.Entities.Board
{
    public interface IBoardAdminMapping : IEntity<Guid>
    {
        Guid BoardId { get; set; }

        Guid UserId { get; set; }
    }
}
