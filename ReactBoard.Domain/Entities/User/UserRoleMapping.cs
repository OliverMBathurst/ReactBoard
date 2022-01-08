using ReactBoard.Domain.Common;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Domain.Entities.User
{
    public class UserRoleMapping : Entity<int>, IUserRoleMapping
    {
        public UserRoleMapping() { }

        public UserRole Role { get; set; }
    }
}