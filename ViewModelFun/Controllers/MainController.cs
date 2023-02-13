using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class MainController : Controller
{
    private readonly ILogger<MainController> _logger;

    public MainController(ILogger<MainController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public ViewResult Index()
    {
        string message = "Hello there, this is an striiiing";
        return View("Index", message);
    }
    [HttpGet("/numbers")]
    public ViewResult Numbers()
    {
        List<int> numbers = new List<int>{1, 10, 15, 2, 45};
        return View("Numbers", numbers);
    }

    [HttpGet("/user")]
    public ViewResult ViewUser()
    {
        User user = new User();
        user.FirstName = "John";
        user.LastName = "Meme";
        return View("ViewUser", user);
    }

    [HttpGet("/users")]
    public ViewResult ViewUsers()
    {
        List<User> users = new List<User>
        {
            new User() { FirstName = "dan", LastName = "theman"},
            new User() {FirstName="bill", LastName="swill"}
        };
        return View("ViewUsers", users);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
