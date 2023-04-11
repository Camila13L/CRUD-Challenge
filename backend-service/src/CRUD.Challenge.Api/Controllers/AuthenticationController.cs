using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Challenge.Api.Filters;
using CRUD.Challenge.Application.Common.Errors;
using CRUD.Challenge.Application.Common.Interfaces.Errors;
using CRUD.Challenge.Application.Interfaces;
using CRUD.Challenge.Application.Services.Authentication;
using CRUD.Challenge.Contracts.Authentication;
using CRUD.Challenge.Domain.Common.Errors;
using ErrorOr;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
namespace CRUD.Challenge.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(ResgisterRequest request)
    {
        // , List<IError>>
            ErrorOr<AuthenticationResult> registerResult = await _authenticationService.Register
            (
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
            );


        return registerResult.Match(
            autResult => Ok(MapAuthResult(autResult)),
            errors => Problem(errors)
            );
      
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        ErrorOr<AuthenticationResult> loginResult = await _authenticationService.Login(request.Email, request.Password);

        if (loginResult.IsError && loginResult.FirstError == HttpErrors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: loginResult.FirstError.Description);
        }

        return loginResult.Match(
              autResult => Ok(MapAuthResult(autResult)),
              errors => Problem(errors.ToList())
             );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authresult)
    {
         AuthenticationResponse authenticationResponse = 
         new AuthenticationResponse
                        (
                        authresult.user.Id,
                        authresult.user.FirstName,
                        authresult.user.LastName,
                        authresult.user.Email,
                        authresult.token
                        );

        return authenticationResponse;
    }
}

