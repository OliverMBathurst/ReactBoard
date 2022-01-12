using ReactBoard.Domain.Common;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.User
{
    public interface IUserService : IEntityService<User, int>
    {
        User Authenticate(string username, string password);

        Task DeleteUserAsync(int userId);
    }
}