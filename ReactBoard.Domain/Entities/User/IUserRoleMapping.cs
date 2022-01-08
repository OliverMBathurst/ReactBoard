using ReactBoard.Domain.Common;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Domain.Entities.User
{
    public interface IUserRoleMapping : IEntity<int>
    {
        UserRole Role { get; set; }
    }
}
