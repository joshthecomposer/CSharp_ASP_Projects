using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FullFormValidation.Models;

namespace FullFormValidation.Controllers;

public class HomeController : Controller
{
    static User? user;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("/")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            user = newUser;
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("/success")]
    public ViewResult Success()
    {
        return View(user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
