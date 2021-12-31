using ReactChan.Domain.Interfaces;
using System;
using static ReactChan.Domain.Entities.User.Enums;

namespace ReactChan.Domain.Entities.User
{
    public interface IUser : IEntity<Guid>
    {
        string UserName { get; set; }

        string EmailAddress { get; set; }

        UserRole Role { get; set; }

        bool HasAnyRole(params UserRole[] roles);
    }
}
