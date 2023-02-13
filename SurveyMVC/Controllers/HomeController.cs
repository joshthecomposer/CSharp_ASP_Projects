using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SurveyMVC.Models;

namespace SurveyMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

        [HttpPost("process")]
    public IActionResult Process(User user)
    {
        return RedirectToAction("result", user);
    }

    [HttpGet("result")]
    public ViewResult Result(User user)
    {
        return View("result", user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
