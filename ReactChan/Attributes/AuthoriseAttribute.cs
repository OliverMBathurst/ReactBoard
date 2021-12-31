using System;
using static ReactChan.Domain.Entities.User.Enums;

namespace ReactChan.Attributes
{
    public class AuthoriseAttribute : Attribute
    {
        public UserRole[] Roles { get; }

        public AuthoriseAttribute(params UserRole[] roles)
        {
            Roles = roles;
        }
    }
}