using ReactChan.Domain.Interfaces;
using System;

namespace ReactChan.Domain.Entities.User
{
    public interface IUser : IEntity<Guid>
    {
        string Name { get; set; }

        string EmailAddress { get; set; }
    }
}
