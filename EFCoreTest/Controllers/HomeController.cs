using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFCoreTest.Models;

namespace LearningSession.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet("")]
    public ViewResult Index()
    {
        List<User> allUsers = _context.Users.ToList();
        ViewBag.AllUsers = allUsers;
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(User newUser)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else 
        {
            List<User> allUsers = _context.Users.ToList();
            ViewBag.AllUsers = allUsers;
            return View("Index");
        }
    }

    [HttpGet("/view/update/{id}")]
    public ViewResult ViewUpdate(int id)
    {
        return View("ViewUpdate");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
