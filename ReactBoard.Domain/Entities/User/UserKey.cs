using System;

namespace ReactBoard.Domain.Entities.User
{
    readonly public struct UserKey : IUserKey, IEquatable<UserKey>
    {
        public UserKey(int? userId)
        {
            UserId = userId;
        }

        public int? UserId { get; }

        public bool Equals(UserKey other)
        {
            return UserId != null
                && other.UserId != null
                && UserId == other.UserId;
        }
    }
}