using ReactBoard.Domain.Common;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Domain.Entities.User
{
    public interface IUser : IEntity<int>
    {
        string Username { get; set; }

        string Password { get; set; }

        string Salt { get; set; }

        string PasswordHash { get; set; }

        string Token { get; set; }

        UserRole Role { get; set; }

        bool HasAnyRole(params UserRole[] roles);
    }
}
