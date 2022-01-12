using ReactBoard.Domain.Common;
using System.Linq;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Domain.Entities.User
{
    public class User : Entity<int>, IUser
    {
        public User() { }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public string Salt { get; set; }

        public string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        public bool HasAnyRole(params UserRole[] roles)
        {
            return roles.Any(r => r == Role);
        }
    }
}
