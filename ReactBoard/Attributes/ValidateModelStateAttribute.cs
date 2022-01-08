﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReactBoard.Models.Api;
using System.Linq;

namespace ReactBoard.Attributes
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToList();

                var response = new ErrorResponseDto
                {
                    Errors = errors
                };

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
