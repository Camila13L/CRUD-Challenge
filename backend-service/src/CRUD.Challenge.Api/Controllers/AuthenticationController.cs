using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Challenge.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Challenge.Api.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    
    [HttpPost("register")]
    public IActionResult Post(ResgisterRequest request)
    {
        return Ok(request);
    }


    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(request);
    }
}

