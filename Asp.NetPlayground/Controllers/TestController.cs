using Asp.NetPlayground.Model;
using Microsoft.AspNetCore.Mvc;
using static System.IO.File;

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

    [HttpGet("get-pics")]
    public async Task<ViewResult> GetPics()
    {
        var    firstFile      = await ReadAllBytesAsync("Content/first.jpeg");
        var    secondFile     = await ReadAllBytesAsync("Content/second.jpg");
        string firstByteData  = Convert.ToBase64String(firstFile);
        string secondByteData = Convert.ToBase64String(secondFile);
        var model = new IdentityDocumentPicturesModel
        {
            FrontSideContentType = "image/jpeg",
            BackSideContentType  = "image/jpg",
            FrontSideBytes       = firstByteData,
            BackSideBytes        = secondByteData
        };
        return View("~/Views/IdentityDocumentFiles.cshtml", model);
    }
}