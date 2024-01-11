using Microsoft.AspNetCore.Mvc;

namespace Asp.NetPlayground.Controllers;

[DbSessionAttributeActionFilter]
[Route("test")]
public class TestController : Controller
{
    [HttpPost("post")]
    public async Task<IActionResult> TestPosts()
    {
        await Task.FromResult(Task.CompletedTask);
        return Ok();
    }
}