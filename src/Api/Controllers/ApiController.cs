﻿using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class ApiController : Controller
    {
        [NonAction]
        public IActionResult Problem(List<Error> errors)
        {
            HttpContext.Items["errors"] = errors;

            var firstError = errors[0];

            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: firstError.Description);
        }

    }
}
