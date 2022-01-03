using ReactBoard.Domain.Interfaces;
using System;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Domain.Entities.User
{
    public interface IUserRoleMapping : IEntity<Guid>
    {
        Guid UserId { get; set; }

        UserRole Role { get; set; }
    }
}
