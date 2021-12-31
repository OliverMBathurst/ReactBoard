using ReactChan.Domain.Entities.User;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;

namespace ReactChan.Infrastructure.Repositories.User
{
    public class UserRoleMappingRepository : EntityRepository<UserRoleMapping, Guid>, IUserRoleMappingRepository
    {
        public UserRoleMappingRepository(ApplicationDbContext context) : base(context) { }
    }
}
