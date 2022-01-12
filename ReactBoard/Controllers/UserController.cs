using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactBoard.Attributes;
using ReactBoard.Domain.Entities.User;
using ReactBoard.Models.Api;
using ReactBoard.Models.User;
using System.Linq;
using System.Threading.Tasks;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Controllers
{
    [Route("[controller]")]
    public class UserController : EntityApiController<User, int>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) : base(userService) 
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);
            if (user == null)
                return BadRequest("Username and/or password is incorrect");

            UserDto userDto = user;
            return Ok(userDto);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorise(UserRole.Admin)]
        public async Task DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
        }

        [HttpGet]
        [Authorise(UserRole.Admin)]
        public override IActionResult GetAllEntities()
        {
            return Ok(_userService.GetAll()
                .Select(x => new UserDto(x))
                .ToList());
        }

        [HttpGet]
        [Authorise(UserRole.Admin)]
        [Route("{id}")]
        public override async Task<IActionResult> GetEntityById([FromRoute] int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            UserDto userDto = user;
            return Ok(userDto);
        }
    }
}