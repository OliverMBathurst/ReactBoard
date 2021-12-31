using Microsoft.AspNetCore.Mvc;
using ReactChan.Attributes;
using ReactChan.Controllers.Abstract;
using ReactChan.Domain.Entities.User;
using System;
using static ReactChan.Domain.Entities.User.Enums;

namespace ReactChan.Controllers.Entities
{
    [ApiController]
    public class UserController : EntityApiController<User, Guid>
    {
        public UserController(IUserService userService) : base(userService) { }

        [Authorise(UserRole.Admin)]
        public override IActionResult GetAllEntities()
        {
            return base.GetAllEntities();
        }
    }
}