using ReactBoard.Domain.Entities.User;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ReactBoard.Domain.Services.User
{
    public class UserPasswordSaltingService : IUserPasswordSaltingService
    {
        public string GenerateNewSalt()
        {
            var bytes = new byte[32];
            RandomNumberGenerator.Fill(bytes);
            return BitConverter.ToString(bytes);
        }

        public string GeneratePasswordHash(string password, string salt)
        {
            return BitConverter.ToString(SHA256.Create()
                .ComputeHash(Encoding.Default.GetBytes(password + salt)));
        }

        public bool ValidatePassword(string password, string salt, string passwordHash)
        {
            return SHA256.Create().ComputeHash(Encoding.Default.GetBytes(password + salt))
                .SequenceEqual(Encoding.Default.GetBytes(passwordHash));
        }
    }
}