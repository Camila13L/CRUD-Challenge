using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Challenge.Api.Filters;
using CRUD.Challenge.Application.Authentication.Commands.Register;
using CRUD.Challenge.Application.Authentication.Common;
using CRUD.Challenge.Application.Authentication.Queries.Login;
using CRUD.Challenge.Application.Common.Errors;
using CRUD.Challenge.Application.Common.Interfaces.Authentication;
using CRUD.Challenge.Application.Common.Interfaces.Errors;
using CRUD.Challenge.Application.Interfaces;
using CRUD.Challenge.Application.Interfaces.Authentication;
using CRUD.Challenge.Contracts.Authentication;
using CRUD.Challenge.Domain.Common.Errors;
using ErrorOr;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
namespace CRUD.Challenge.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediatR;

    public AuthenticationController(ISender mediatR)
    {
        _mediatR = mediatR;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(ResgisterRequest request)
    {
        RegisterCommand command = new RegisterCommand(
        request.FirstName,
        request.LastName,
        request.Email,
        request.Password
        );

        ErrorOr<AuthenticationResult> registerResult = await _mediatR.Send(command);


        return registerResult.Match(
            autResult => Ok(MapAuthResult(autResult)),
            errors => Problem(errors)
            );
      
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        LoginQuery query = new LoginQuery(request.Email, request.Password);

        ErrorOr<AuthenticationResult> loginResult = await _mediatR.Send(query);

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

