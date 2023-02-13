using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateValidator.Models;

namespace DateValidator.Controllers;

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

    [HttpPost("/register")]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Success", user);
        }
        else 
        {
            return View("Index");
        }
    }

    [HttpGet("/success")]
    public ViewResult Success(User user)
    {

        return View("Success", user);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
