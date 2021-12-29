using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactChan.Controllers.Abstract;
using ReactChan.Domain.Entities.User;
using System;

namespace ReactChan.Controllers.Entities
{
    [ApiController]
    public class UserController : EntityApiController<IUser, Guid>
    {
        public UserController(IUserService userService) : base(userService) { }

        [Authorize(Roles = Constants.Roles.Admin)]
        public override IActionResult GetAllEntities()
        {
            return base.GetAllEntities();
        }
    }
}