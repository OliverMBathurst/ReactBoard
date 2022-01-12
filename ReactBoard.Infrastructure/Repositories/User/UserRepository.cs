using Microsoft.EntityFrameworkCore;
using ReactBoard.Domain.Entities.User;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using System.Threading.Tasks;
using _User = ReactBoard.Domain.Entities.User.User;

namespace ReactBoard.Infrastructure.Repositories.User
{
    public sealed class UserRepository : EntityRepository<_User, int>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Set<_User>()
                .FirstOrDefaultAsync(x => x.Id.Equals(userId));

            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}