using ReactBoard.Domain.Common;

namespace ReactBoard.Domain.Entities.User
{
    public interface IUserRepository : IEntityRepository<User, int>, IHasStatistic<int>
    {
    }
}
