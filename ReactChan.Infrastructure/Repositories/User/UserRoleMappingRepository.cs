using ReactBoard.Domain.Entities.User;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using System;

namespace ReactBoard.Infrastructure.Repositories.User
{
    public class UserRoleMappingRepository : EntityRepository<UserRoleMapping, Guid>, IUserRoleMappingRepository
    {
        public UserRoleMappingRepository(ApplicationDbContext context) : base(context) { }
    }
}
