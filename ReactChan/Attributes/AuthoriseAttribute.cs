using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReactChan.Domain.Entities.User;
using static ReactChan.Domain.Entities.User.Enums;

namespace ReactChan.Attributes
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

            var c = (IUser)user; //todo
            context.Result = c.HasAnyRole(_roles) 
                ? new OkResult() 
                : new ForbidResult();
        }
    }
}