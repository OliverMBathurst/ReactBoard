using System.ComponentModel.DataAnnotations;

namespace ReactBoard.API.Models.Api
{
    public sealed class AuthenticationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}