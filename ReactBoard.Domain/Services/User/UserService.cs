using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.User;
using _User = ReactBoard.Domain.Entities.User.User;

namespace ReactBoard.Domain.Services.User
{
    public sealed class UserService : EntityService<_User, int>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository) { }
    }
}
