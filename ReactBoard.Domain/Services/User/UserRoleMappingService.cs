using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.User;

namespace ReactBoard.Domain.Services.User
{
    public sealed class UserRoleMappingService : EntityService<UserRoleMapping, int>, IUserRoleMappingService
    {
        public UserRoleMappingService(IUserRoleMappingRepository repository) : base(repository) { }
    }
}