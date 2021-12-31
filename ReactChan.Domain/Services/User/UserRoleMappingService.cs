using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.User;
using System;

namespace ReactChan.Domain.Services.User
{
    public class UserRoleMappingService : EntityService<UserRoleMapping, Guid>, IUserRoleMappingService
    {
        public UserRoleMappingService(IEntityRepository<UserRoleMapping, Guid> repository) : base(repository) { }
    }
}