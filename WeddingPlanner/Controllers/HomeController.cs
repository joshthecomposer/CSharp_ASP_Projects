using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

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
        int? check = HttpContext.Session.GetInt32("User");
        if (check != null)
        {
            return Redirect($"/users/{check}/dashboard");
        }
        ViewModel vm = new ViewModel();
        return View(vm);
    }

    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("User", newUser.UserId);
            return Redirect("/users/"+newUser.UserId+"/dashboard");
        }
        ViewModel v = new ViewModel {User = newUser, LoginUser = new LoginUser()};
        return View("Index", v);
    }

    public IActionResult Login(LoginUser l)
    {
        ViewModel v = new ViewModel {User = new User(), LoginUser = l};
        if (ModelState.IsValid)
        {
            User? check = _context.Users.SingleOrDefault(u => u.Email == l.Email);
            if (check == null)
            {
                ModelState.AddModelError("Email", "Email or Password Invalid");
                return View("Index", v);
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(l, check.Password!, l.Password);
            if (result == 0)
            {
                ModelState.AddModelError("Password", "Email or Password Invalid");
                return View("Index", v);
            }
            else
            {
                HttpContext.Session.SetInt32("User", check.UserId);
                return Redirect("/users/" + check.UserId + "/dashboard");
            }
        }
        else
        {

            return View("Index", v);
        }
    }

    [HttpGet("/users/{UserId}/dashboard")]
    public IActionResult Dashboard(int UserId)
    {
        if (HttpContext.Session.GetInt32("User") == UserId)
        {   
            ViewBag.User = _context.Users.FirstOrDefault(u=>u.UserId == UserId)!;
            ViewBag.Weddings = _context.Weddings.ToList();
            return View(new Wedding());
        }
        return RedirectToAction("Index");
    }

    [HttpGet("/logout")]
    public RedirectToActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpGet("/weddings/new")]
    public IActionResult WeddingForm()
    {
        User? u = _context.Users.FirstOrDefault(u=>u.UserId == HttpContext.Session.GetInt32("User"))!;
        if (u == null)
        {
            return RedirectToAction("Index");
        }
        ViewBag.UserId = u.UserId;
        return View();
    }
    [HttpPost("/weddings/create")]
    public IActionResult CreateWedding(Wedding w)
    {
        if (ModelState.IsValid)
        {
            _context.Add(w);
            _context.SaveChanges();
            return Redirect("/");
        }
        else
        {
            string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            Console.WriteLine(messages);
            return View("WeddingForm", w);

        }
    }
    [HttpPost]
    public IActionResult DeleteWedding(Wedding w)
    {
        _context.Remove(w);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet("/users/{UserId}/rsvp/{WeddingId}")]
    public IActionResult RSVPToWedding(int userId, int weddingId)
    {
        RSVPList? check = _context.RSVPLists.FirstOrDefault(r => r.UserId == userId && r.WeddingId == weddingId);
        if (check == null)
        {
            RSVPList newRSVP = new RSVPList{UserId = userId, WeddingId = weddingId};
            _context.RSVPLists.Add(newRSVP);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
