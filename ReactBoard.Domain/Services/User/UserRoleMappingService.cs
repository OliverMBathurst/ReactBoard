using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.User;
using System;

namespace ReactBoard.Domain.Services.User
{
    public sealed class UserRoleMappingService : EntityService<UserRoleMapping, Guid>, IUserRoleMappingService
    {
        public UserRoleMappingService(IUserRoleMappingRepository repository) : base(repository) { }
    }
}