using Microsoft.AspNetCore.Mvc;
using ReactBoard.Attributes;
using ReactBoard.Controllers.Abstract;
using ReactBoard.Domain.Entities.User;
using System.Threading.Tasks;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Controllers.Entities
{
    public class UserController : EntityApiController<User, int>
    {
        public UserController(IUserService userService) : base(userService) { }

        [HttpGet]
        [Authorise(UserRole.Admin)]
        public override IActionResult GetAllEntities()
        {
            return base.GetAllEntities();
        }

        [HttpGet]
        [Authorise(UserRole.Admin)]
        [Route("{userId}")]
        public override async Task<IActionResult> GetEntityById([FromRoute] int id)
        {
            return await base.GetEntityById(id);
        }
    }
}