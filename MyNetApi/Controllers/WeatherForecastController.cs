using Microsoft.AspNetCore.Mvc;

namespace MyNetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello, Azure Kubernetes Service from .NET 8!");
    }
}