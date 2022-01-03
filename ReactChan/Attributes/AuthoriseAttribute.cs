using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReactBoard.Domain.Entities.User;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Attributes
{
    public class AuthoriseAttribute : AuthorizeAttribute
    {
        private readonly UserRole[] _roles;

        public AuthoriseAttribute(params UserRole[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return;
            }

            var c = (IUser)user; //todo sort out auth

            if (c.HasAnyRole(_roles)) 
            {
                context.Result = new OkResult();
                return;
            }

            context.Result = new ForbidResult();
        }
    }
}