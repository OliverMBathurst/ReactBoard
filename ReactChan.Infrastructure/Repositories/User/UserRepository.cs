using ReactChan.Domain.Entities.User;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;

namespace ReactChan.Infrastructure.Repositories.User
{
    public class UserRepository : EntityRepository<IUser, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}