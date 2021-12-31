using ReactChan.Domain.Common;
using System;

namespace ReactChan.Domain.Entities.User
{
    public interface IUserRoleMappingRepository : IEntityRepository<UserRoleMapping, Guid>
    {
    }
}