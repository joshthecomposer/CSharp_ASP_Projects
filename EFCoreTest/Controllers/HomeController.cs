#pragma warning disable CS8618
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
        User user = _context.Users.FirstOrDefault(u => u.UserId == id)!;
        return View("ViewUpdate", user);
    }

    [HttpPost("update/{id}")]
    public IActionResult Update(User user, int Id)
    {
        User oldUser = _context.Users.FirstOrDefault(i => i.UserId == Id)!;
        if (ModelState.IsValid)
        {
            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;
            oldUser.Email = user.Email;
            oldUser.Password = user.Password;
            oldUser.UpdatedAt = DateTime.Now;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        else
        {
            return View("ViewUpdate", oldUser);
        }
    }

    [HttpPost("/destroy/{id}")]
    public IActionResult Delete(int id)
    {
        User? user = _context.Users.SingleOrDefault(i => id == i.UserId);
        _context.Users.Remove(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
