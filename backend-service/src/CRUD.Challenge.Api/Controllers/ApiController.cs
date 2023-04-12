using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CRUD.Challenge.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult ProblemX(List<Error> errors)
    {
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                var key = error.Code;
                var value = error.Description;
                modelStateDictionary.AddModelError(key,value);
            }

            return ValidationProblem(modelStateDictionary);
        }

        HttpContext.Items["errors"] = errors;
        Error firstError = errors[0];
        int statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: firstError.Description); 
    }
}

