using ReactBoard.Domain.Common;
using System;

namespace ReactBoard.Domain.Entities.User
{
    public interface IUserRoleMappingRepository : IEntityRepository<UserRoleMapping, Guid>
    {
    }
}