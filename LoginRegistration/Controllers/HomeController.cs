using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginRegistration.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("/users/create")]
    public IActionResult Create(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("User", newUser.UserId);
            return Redirect("/users/" + newUser.UserId);
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("/users/{Id}")]
    public IActionResult ViewOne(int Id)
    {
        if (HttpContext.Session.GetInt32("User") == Id)
        {
            User? u = _context.Users.FirstOrDefault(u=>u.UserId == Id);
            return View(u);
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HttpPost("/users/login")]
    public IActionResult Login(LoginUser u)
    {
        //TODO: User in session.
        if (ModelState.IsValid)
        {
            User? check = _context.Users.SingleOrDefault(e=>e.Email == u.Email);
            if (check == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password.");
                return View("Index");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(u, check.Password, u.Password);
            if (result==0)
            {
                ModelState.AddModelError("Password", "Invalid Email/Password.");
                return View("Index");
            }
            else
            {
                HttpContext.Session.SetInt32("User", check.UserId);
                return Redirect("/users/" + check.UserId);
            }
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("/logout")]
    public RedirectToActionResult Logout()
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
