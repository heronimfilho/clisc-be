using Microsoft.AspNetCore.Mvc;

namespace ClinicScheduler.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController : ControllerBase
{
    [HttpGet]
    [Route("~/status")]
    public IActionResult Get()
    {
        return Ok(new { status = "Backend API is running!", timestamp = DateTime.UtcNow });
    }
}
