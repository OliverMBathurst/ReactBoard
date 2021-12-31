using ReactChan.Domain.Common;
using System;
using System.Linq;
using static ReactChan.Domain.Entities.User.Enums;

namespace ReactChan.Domain.Entities.User
{
    public class User : Entity<Guid>, IUser
    {
        public User(Guid id) : base(id) { }

        public string UserName { get; set; }

        public UserRole Role { get; set; }

        public string EmailAddress { get; set; }

        public bool HasAnyRole(params UserRole[] roles)
        {
            return roles.Any(r => r == Role);
        }
    }
}
