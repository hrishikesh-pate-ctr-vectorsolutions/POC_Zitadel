// Controllers/HomeController.cs

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        var user = User.Claims;
        return View(user);
    }

    public IActionResult UnAuthed()
    {
        string hello = "Hello from UnAuthed Page";
        return View(hello);
    }
}
