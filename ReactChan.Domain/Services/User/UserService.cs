using ReactChan.Domain.Common;
using ReactChan.Domain.Entities.User;
using System;

namespace ReactChan.Domain.Services.User
{
    public class UserService : EntityService<IUser, Guid>, IUserService
    {
        public UserService(IEntityRepository<IUser, Guid> repository) : base(repository) { }
    }
}
