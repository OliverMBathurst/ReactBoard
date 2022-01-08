using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.User;
using System.Threading.Tasks;
using _User = ReactBoard.Domain.Entities.User.User;

namespace ReactBoard.Domain.Services.User
{
    public sealed class UserService : EntityService<_User, int>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<int> GetStatisticAsync()
        {
            return await _userRepository.GetStatisticAsync();
        }
    }
}