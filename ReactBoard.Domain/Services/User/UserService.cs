using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReactBoard.Domain.Common;
using ReactBoard.Domain.Entities.User;
using ReactBoard.Domain.Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using _User = ReactBoard.Domain.Entities.User.User;

namespace ReactBoard.Domain.Services.User
{
    public sealed class UserService : EntityService<_User, int>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPasswordSaltingService _userPasswordSaltingService;
        private readonly AppSettings _appSettings;

        public UserService(
            IUserRepository userRepository,
            IUserPasswordSaltingService userPasswordSaltingService,
            IOptions<AppSettings> options) : base(userRepository) 
        {
            _userRepository = userRepository;
            _userPasswordSaltingService = userPasswordSaltingService;
            _appSettings = options.Value;
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public _User Authenticate(string username, string password)
        {
            var user = _repository.Fetch(x => x.Username == username)
                .SingleOrDefault();

            if (user == null)
                return null;

            if (!_userPasswordSaltingService.ValidatePassword(password, user.Salt, user.PasswordHash))
                return null;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret)), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            user.Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return user;
        }
    }
}