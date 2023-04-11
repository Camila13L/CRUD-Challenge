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

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

