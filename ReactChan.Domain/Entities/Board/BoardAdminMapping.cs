using ReactChan.Domain.Common;
using System;

namespace ReactChan.Domain.Entities.Board
{
    public class BoardAdminMapping : Entity<Guid>, IBoardAdminMapping
    {
        public BoardAdminMapping(Guid id) : base(id) { }

        public Guid BoardId { get; set; }

        public Guid UserId { get; set; }
    }
}