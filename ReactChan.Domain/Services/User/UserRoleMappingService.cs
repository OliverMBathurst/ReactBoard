using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.User;
using System;

namespace ReactChan.Domain.Services.User
{
    public class UserRoleMappingService : EntityService<IUserRoleMapping, Guid>, IUserRoleMappingService
    {
        public UserRoleMappingService(IEntityRepository<IUserRoleMapping, Guid> repository) : base(repository) { }
    }
}