using Microsoft.AspNetCore.Mvc;

namespace Countdown.Controllers;
public class MainController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        ViewBag.now = DateTime.Now;
        ViewBag.end = new DateTime(2023, 2, 13, 17, 30, 0);
        ViewBag.remaining = ViewBag.end - ViewBag.now;
        return View();
    }
}