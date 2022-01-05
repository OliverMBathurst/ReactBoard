using ReactBoard.Domain.Common;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Domain.Entities.User
{
    public interface IUserRoleMapping : IEntity<int>
    {
        int UserId { get; set; }

        UserRole Role { get; set; }
    }
}
