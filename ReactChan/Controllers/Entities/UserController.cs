using Microsoft.AspNetCore.Mvc;
using ReactBoard.Attributes;
using ReactBoard.Controllers.Abstract;
using ReactBoard.Domain.Entities.User;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Controllers.Entities
{
    [ApiController]
    public class UserController : EntityApiController<User, UserKey>
    {
        public UserController(IUserService userService) : base(userService) { }

        [Authorise(UserRole.Admin)]
        public override IActionResult GetAllEntities()
        {
            return base.GetAllEntities();
        }
    }
}