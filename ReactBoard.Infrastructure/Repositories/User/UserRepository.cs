using ReactBoard.Domain.Entities.User;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using _User = ReactBoard.Domain.Entities.User.User;

namespace ReactBoard.Infrastructure.Repositories.User
{
    public sealed class UserRepository : EntityRepository<_User, UserKey>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}