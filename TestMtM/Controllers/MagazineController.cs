using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestMtM.Models;

namespace TestMtM.Controllers;

public class MagazineController : Controller
{

    private MyContext _context;
    private readonly ILogger<MagazineController> _logger;


    public MagazineController(ILogger<MagazineController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public RedirectToActionResult Create(Magazine m)
    {  
        if (ModelState.IsValid)
        {
            _context.Add(m);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpPost]
    public RedirectToActionResult CreateSub(Subscription s)
    {
        if (ModelState.IsValid)
        {
            _context.Add(s);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }    
}