using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.User;
using System;
using _User = ReactChan.Domain.Entities.User.User;

namespace ReactChan.Domain.Services.User
{
    public class UserService : EntityService<_User, Guid>, IUserService
    {
        public UserService(IEntityRepository<_User, Guid> repository) : base(repository) { }
    }
}
