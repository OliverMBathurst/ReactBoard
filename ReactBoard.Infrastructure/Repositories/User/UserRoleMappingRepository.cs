using ReactBoard.Domain.Entities.User;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;

namespace ReactBoard.Infrastructure.Repositories.User
{
    public sealed class UserRoleMappingRepository : EntityRepository<UserRoleMapping, int>, IUserRoleMappingRepository
    {
        public UserRoleMappingRepository(DatabaseContext context) : base(context) { }
    }
}
