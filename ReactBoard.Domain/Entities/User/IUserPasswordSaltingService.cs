namespace ReactBoard.Domain.Entities.User
{
    public interface IUserPasswordSaltingService
    {
        string GenerateNewSalt();

        string GeneratePasswordHash(string password, string salt);

        bool ValidatePassword(string password, string salt, string passwordHash);
    }
}
