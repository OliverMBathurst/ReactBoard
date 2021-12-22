using ReactChan.Domain.Interfaces;
using System;
using static ReactChan.Domain.Entities.User.Enums;

namespace ReactChan.Domain.Entities.User
{
    public interface IUserRoleMapping : IEntity<Guid>
    {
        Guid UserId { get; set; }

        UserRole Role { get; set; }
    }
}
