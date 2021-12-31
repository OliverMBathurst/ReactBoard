using ReactChan.Domain.Entities.User;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System;
using _User = ReactChan.Domain.Entities.User.User;

namespace ReactChan.Infrastructure.Repositories.User
{
    public class UserRepository : EntityRepository<_User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}