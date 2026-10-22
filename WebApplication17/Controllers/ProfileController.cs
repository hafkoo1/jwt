using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication17.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : Controller
{
    [HttpGet]
    [Authorize]
    public IActionResult GetProfile()
    {
        return Ok("You are auth.");
    }
}