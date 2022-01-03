using ReactBoard.Domain.Common;
using System;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Domain.Entities.User
{
    public class UserRoleMapping : Entity<Guid>, IUserRoleMapping
    {
        public UserRoleMapping(Guid id) : base(id) { }

        public Guid UserId { get; set; }

        public UserRole Role { get; set; }
    }
}