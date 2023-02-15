using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestMtM.Models;

namespace TestMtM.Controllers;

public class PersonController : Controller
{

    private MyContext _context;
    private readonly ILogger<PersonController> _logger;


    public PersonController(ILogger<PersonController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public RedirectToActionResult Create(Person p)
    {
        if (ModelState.IsValid)
        {
            _context.Add(p);
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