using Microsoft.AspNetCore.Mvc;

namespace CRUD.Challenge.Api.Controllers;

[Route("[controller]")]
public class DinnerController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> ListDinner()
    {
        var s = new string[] { "pato - 1", "pato - 2" };
        return await Task.Run(() => Ok(s)); 
    }
}

