using ReactChan.Domain.Common;
using System;
using static ReactChan.Domain.Entities.User.Enums;

namespace ReactChan.Domain.Entities.User
{
    public class UserRoleMapping : Entity<Guid>, IUserRoleMapping
    {
        public UserRoleMapping(Guid id) : base(id) { }

        public Guid UserId { get; set; }

        public UserRole Role { get; set; }
    }
}