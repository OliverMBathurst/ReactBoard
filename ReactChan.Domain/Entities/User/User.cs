using ReactChan.Domain.Common;
using System;

namespace ReactChan.Domain.Entities.User
{
    public class User : Entity<Guid>, IUser
    {
        public User(Guid id) : base(id) { }

        public string Name { get; set; }

        public string EmailAddress { get; set; }
    }
}
