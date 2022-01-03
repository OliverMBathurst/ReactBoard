using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.User;
using System;

namespace ReactBoard.Domain.Services.User
{
    public class UserRoleMappingService : EntityService<UserRoleMapping, Guid>, IUserRoleMappingService
    {
        public UserRoleMappingService(IEntityRepository<UserRoleMapping, Guid> repository) : base(repository) { }
    }
}