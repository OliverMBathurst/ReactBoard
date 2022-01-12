using System.ComponentModel.DataAnnotations;

namespace ReactBoard.Models.Api
{
    public class AuthenticationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}