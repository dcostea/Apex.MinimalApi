using Microsoft.AspNetCore.Mvc;

namespace Apex.MinimalApi.Controllers;

[ApiController]
[Route("{controller}")]
public class DefaultController : ControllerBase
{
    [HttpGet("/ping")]
    public ActionResult<string> Ping()
    {
        return Ok("Ping is OK");
    }
}

