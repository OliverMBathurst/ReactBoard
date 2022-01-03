using ReactBoard.Domain.Interfaces;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Domain.Entities.User
{
    public interface IUser : IEntity<UserKey>
    {
        string UserName { get; set; }

        UserRole Role { get; set; }

        bool HasAnyRole(params UserRole[] roles);
    }
}
