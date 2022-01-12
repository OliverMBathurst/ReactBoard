using static ReactBoard.Domain.Entities.User.Enums;
using _User = ReactBoard.Domain.Entities.User.User;

namespace ReactBoard.Models.User
{
    public class UserDto
    {
        public UserDto() { }

        public UserDto(_User user)
        {
            Username = user.Username;
            Token = user.Token;
            Role = user.Role;
        }

        public string Username { get; set; }

        public string Token { get; set; }

        public UserRole Role { get; set; }

        public static implicit operator UserDto(_User user)
        {
            return new UserDto { 
                Username = user.Username, 
                Token = user.Token, 
                Role = user.Role 
            };
        }
    }
}