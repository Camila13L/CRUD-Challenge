using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Challenge.Application.Interfaces;
using CRUD.Challenge.Application.Services.Authentication;
using CRUD.Challenge.Contracts.Authentication;

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
        AuthenticationResult registerResult = await _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        var registerResponse = new AuthenticationResponse(registerResult.Id, registerResult.FirstName, registerResult.LastName, registerResult.Email, registerResult.token);
        return  Ok(registerResponse);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        AuthenticationResult loginResult = await _authenticationService.Login(request.Email, request.Password);
        AuthenticationResponse loginResponse = new AuthenticationResponse(loginResult.Id, loginResult.FirstName, loginResult.LastName, loginResult.Email, loginResult.token);
        return Ok(loginResponse);
    }
}

