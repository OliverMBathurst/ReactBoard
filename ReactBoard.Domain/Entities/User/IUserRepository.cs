using ReactBoard.Domain.Common;
using System.Threading.Tasks;

namespace ReactBoard.Domain.Entities.User
{
    public interface IUserRepository : IEntityRepository<User, int>
    {
        Task DeleteUserAsync(int userId);
    }
}
