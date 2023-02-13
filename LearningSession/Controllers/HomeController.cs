using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LearningSession.Models;

namespace LearningSession.Controllers;

public class HomeController : Controller
{
    static User user = new User();

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("Name") != null)
        {
            return RedirectToAction("Dashboard");
        }
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(User newUser)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("Name", newUser.Name);
            HttpContext.Session.SetInt32("Number", 22);
            return RedirectToAction("Dashboard");
        }
        return View("Index", newUser);
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("Name") == null)
        {
            return RedirectToAction("Index");
        }
        ViewBag.Name = HttpContext.Session.GetString("Name");
        return View("Dashboard");
    }

    [HttpPost("/math/{input}")]
    public IActionResult Math(int input)
    {
        Random r = new Random();
        int? currentNumber = HttpContext.Session.GetInt32("Number");
        switch (input)
        {
            case 0:
                currentNumber++;
                Console.WriteLine(input);
                break;
            case 1:
                currentNumber--;
                break;
            case 2:
                currentNumber*=2;
                break;
            case 3:
                currentNumber+=r.Next(1, 11);
                break;
            default:
                break;
        }
        HttpContext.Session.SetInt32("Number", (int)currentNumber!);
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
