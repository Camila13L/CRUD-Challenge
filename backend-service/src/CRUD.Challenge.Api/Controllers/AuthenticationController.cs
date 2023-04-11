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
using ErrorOr;
using FluentResults;
using Microsoft.AspNetCore.Mvc;


namespace CRUD.Challenge.Api.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
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


        return registerResult.MatchFirst(
            autResult => Ok(MapAuthResult(autResult)),
            firstError=> Problem(statusCode: StatusCodes.Status409Conflict, detail: firstError.Description)
            );
      
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        AuthenticationResult loginResult = await _authenticationService.Login(request.Email, request.Password);
        AuthenticationResponse loginResponse = new AuthenticationResponse(loginResult.user.Id, loginResult.user.FirstName, loginResult.user.LastName, loginResult.user.Email, loginResult.token);
        return Ok(loginResponse);
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authresult)
    {
        return new AuthenticationResponse
                        (
                        authresult.user.Id,
                        authresult.user.FirstName,
                        authresult.user.LastName,
                        authresult.user.Email,
                        authresult.token
                        );
    }
}

