using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }


    public ViewResult Index()
    {
        ViewBag.All = _context.Products.ToList();
        return View();
    }

    [HttpGet("/categories")]
    public ViewResult Categories()
    {
        ViewBag.All = _context.Categories.ToList();
        return View();
    }
    [HttpPost]
    public IActionResult CategoryCreate(Category c)
    {
        if (ModelState.IsValid)
        {
            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
        return View("Categories", c);
    }
    [HttpPost]
    public IActionResult ProductCreate(Product p)
    {
        if (ModelState.IsValid)
        {
            _context.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Index", p);
    }

    [HttpGet("/categories/{Id}")]
    public ViewResult ViewCategory(int Id, Association i)
    {
        ViewBag.Category = _context.Categories.Include(a=>a.Products).ThenInclude(a=>a.Product).FirstOrDefault(c=>c.CategoryId == Id);
        ViewBag.Products = _context.Products.ToList();
        return View(i);
    }

    [HttpGet("/products/{Id}")]
    public ViewResult ViewProduct(int Id, Association i)
    {
        ViewBag.Product = _context.Products.Include(p=>p.Categories).ThenInclude(a=>a.Category).FirstOrDefault(p=>p.ProductId == Id);
        ViewBag.Categories = _context.Categories.ToList();
        return View(i);
    }

    [HttpPost]
    public IActionResult AssociationCreate(Association a)
    {
        if (ModelState.IsValid)
        {
            Association? check = _context.Associations.FirstOrDefault(c=>c.ProductId == a.ProductId && c.CategoryId == a.CategoryId);
            if (check == null)
            {
                _context.Add(a);
                _context.SaveChanges();
            }
        }
        return Redirect("/categories/" + a.CategoryId);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
